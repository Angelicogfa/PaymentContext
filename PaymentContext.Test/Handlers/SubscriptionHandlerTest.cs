using System;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Test.Mocks;
using Xunit;

namespace PaymentContext.Test.Handlers
{
    public class SubscriptionHandlerTest
    {
        readonly IStudentyRepository repository;
        readonly IEmailService emailService;

        public SubscriptionHandlerTest()
        {
            repository = new FakeStudentyRepository();
            emailService = new FakeEmailService();
        }

        [Fact]
        public void PodeRetornarErroSeDocumentoExistir()
        {
            SubscriptionHandler handler = new SubscriptionHandler(repository, emailService);

            var command = new CreateBoletoSubscriptionCommand();
            command.BarCode = "1323";
            command.BoletoNumber = "85";
            command.City = "NEW YORK";
            command.Contry = "NY";
            command.Document = "99999999999";
            command.Email = "batman2@dc.com";
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.FirstName = "Bruce";
            command.LastName = "Wane";
            command.Neighborhood = "Bairro DC";
            command.Number = "123";
            command.PaidDate = DateTime.Now;
            command.Payer = "CURINGA";
            command.PayerDocument = "3216";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "curinga@dc.com";
            command.PaymentNumber = "2896";
            command.State = "DC";
            command.Street = "USA";
            command.Total = 10;
            command.TotalPaid = 10;
            command.ZipCode = "123";

            var result = handler.Handler(command) as CommandResult;

            Assert.NotNull(result);
            Assert.False(result.Sucess);
            Assert.True(handler.Invalid);
            Assert.Contains(handler.Notifications, t=> t.Property.Equals("Document"));
        }
    }
}