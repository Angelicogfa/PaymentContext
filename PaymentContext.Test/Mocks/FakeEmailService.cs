using PaymentContext.Domain.Services;

namespace PaymentContext.Test.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string To, string Email, string Subject, string Body)
        {
            //ToDo Send mail
        }
    }
}