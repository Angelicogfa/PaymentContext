namespace PaymentContext.Domain.Services
{
    public interface IEmailService
    {
        void Send(string To, string Email, string Subject, string Body);
    }
}