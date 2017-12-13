using System.Text.RegularExpressions;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ObjectValue
    {
        public Email(string address)
        {
            Address = address;

            if(string.IsNullOrEmpty(address))
                AddNotification(nameof(Address), "Email não informado!");
            else if(!Regex.IsMatch(address, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                AddNotification(nameof(Address), "Email não é válido!");
        }

        public string Address { get; private set; }
    }    
}