using System;
using PaymentContext.Domain.ValueObject;

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
        Document document,
        string address,
        Email email) : base(paidDate, 
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