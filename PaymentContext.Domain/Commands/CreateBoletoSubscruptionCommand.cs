using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public CreateBoletoSubscriptionCommand()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Contry { get; private set; }
        public string ZipCode { get; private set; }

        public void Validate()
        {
             AddNotifications(new Contract().Requires()
            .HasMinLen(FirstName, 3, "FistName", "O nome deve ter no mínimo 3 caractéres!")
            .HasMinLen(LastName, 2, "LastName", "O sobrenome deve ter no mínimo 2 caractéres!")
            .HasMaxLen(FirstName, 40, "FirstName", "Nome deve conter 40 caractéres"));
        }
    }
}