using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email) : base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
        {
        }

        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
    }
}