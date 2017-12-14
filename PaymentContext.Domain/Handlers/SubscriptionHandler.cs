using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Repositories;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
     Notifiable,
     IHandler<CreateBoletoSubscriptionCommand>
    {
        readonly IStudentyRepository studentyRepository;
        public SubscriptionHandler(IStudentyRepository studentyRepository)
        {
            this.studentyRepository = studentyRepository;
        }

        public ICommandResult Handler(CreateBoletoSubscriptionCommand command)
        {
            
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}