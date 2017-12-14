using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
     Notifiable,
     IHandler<CreateBoletoSubscriptionCommand>,
     IHandler<CreatePayPalSubscriptionCommand>,
     IHandler<CreateCreditCardSubscriptionCommand>
    {
        readonly IStudentyRepository studentyRepository;
        readonly IEmailService emailService;
        public SubscriptionHandler(IStudentyRepository studentyRepository, IEmailService emailService)
        {
            this.studentyRepository = studentyRepository;
            this.emailService = emailService;
        }

        public ICommandResult Handler(CreateBoletoSubscriptionCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            //Verifica se o documento já esta cadastrado!
            if (studentyRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            if (studentyRepository.EmailExists(command.Email))
                AddNotification("Email", "Este email já está em uso");

            //Entities e V.O.
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Contry, command.ZipCode);
            var document = new Document(command.Document, EDocumentType.CPF);
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));

            var payment = new BoletoPayment(command.BarCode,
            command.BoletoNumber,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer, new Document(command.PayerDocument, command.PayerDocumentType),
            address, email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupa as validações
            AddNotifications(name, document, address, student, subscription, payment);

            //Valida
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            //Salva as informacoes
            studentyRepository.CreateSubscription(student);

            //Envia e-mail de boas vindas
            emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada!");

            //retorna as informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handler(CreatePayPalSubscriptionCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            //Verifica se o documento já esta cadastrado!
            if (studentyRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            if (studentyRepository.EmailExists(command.Email))
                AddNotification("Email", "Este email já está em uso");

            //Entities e V.O.
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Contry, command.ZipCode);
            var document = new Document(command.Document, EDocumentType.CPF);
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));

            var payment = new PayPalPayment(command.TransactionCode,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer, new Document(command.PayerDocument, command.PayerDocumentType),
            address, email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupa as validações
            AddNotifications(name, document, address, student, subscription, payment);

            //Valida
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            //Salva as informacoes
            studentyRepository.CreateSubscription(student);

            //Envia e-mail de boas vindas
            emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada!");

            //retorna as informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handler(CreateCreditCardSubscriptionCommand command)
        {
            //Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            //Verifica se o documento já esta cadastrado!
            if (studentyRepository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            if (studentyRepository.EmailExists(command.Email))
                AddNotification("Email", "Este email já está em uso");

            //Entities e V.O.
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Contry, command.ZipCode);
            var document = new Document(command.Document, EDocumentType.CPF);
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));

            var payment = new CreditCardPayment(command.CardHolderName,
            command.CardNumber,
            command.LastTransactionNumber,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer, new Document(command.PayerDocument, command.PayerDocumentType),
            address, email);

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupa as validações
            AddNotifications(name, document, address, student, subscription, payment);

            //Valida
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura");

            //Salva as informacoes
            studentyRepository.CreateSubscription(student);

            //Envia e-mail de boas vindas
            emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo", "Sua assinatura foi criada!");

            //retorna as informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}