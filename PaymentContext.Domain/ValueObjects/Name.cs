using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public sealed class Name : ObjectValue
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract().Requires()
            .HasMinLen(FirstName, 3, "Name.FistName", "O nome deve ter no mínimo 3 caractéres!")
            .HasMinLen(LastName, 2, "Name.LastName", "O sobrenome deve ter no mínimo 2 caractéres!")
            .HasMaxLen(FirstName, 40, "Name.FirstName", "Nome deve conter 40 caractéres"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }    
}