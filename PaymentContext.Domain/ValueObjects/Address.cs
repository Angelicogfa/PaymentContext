using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ObjectValue
    {
        public Address(string street, string number, string neighborhood, string city, string state, string contry, string zipCode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Contry = contry;
            ZipCode = zipCode;

            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caractéres!")
            .HasMinLen(City, 3, "Address.City", "A cidade deve conter pelo menos 3 caractéres!")
            .HasMinLen(State, 2, "Address.State", "O estado deve conter pelo menos 3 caractéres!")
            .HasMinLen(Contry, 3, "Address.Contry", "O país deve conter pelo menos 3 caractéres!")
            .IsNotNullOrEmpty(ZipCode,"Address.ZipCode", "O CEP deve ser informado!")
            .IsNotNullOrEmpty(Number,"Address.Number", "O número deve ser informado!"));
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Contry { get; private set; }
        public string ZipCode { get; private set; }
    }    
}