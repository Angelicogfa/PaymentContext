using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string CardHolderName,
        string CardNumber,
        string LastTransactionNumber,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        string document,
        string address,
        string email) : base(paidDate, 
                        expireDate, 
                        total, 
                        totalPaid, 
                        payer, 
                        document, 
                        address, 
                        email)
        {
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}