using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public sealed class Name : ObjectValue
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if(string.IsNullOrEmpty(firstName))
                AddNotification(nameof(FirstName), "Nome não informado!");

            if(string.IsNullOrEmpty(lastName))
                AddNotification(nameof(LastName), "Sobrenome não informado!");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }    
}