using System;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string TransactionCode,
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

        public string TransactionCode { get; private set; }
    }
}