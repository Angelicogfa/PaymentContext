using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ObjectValue
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }    
}