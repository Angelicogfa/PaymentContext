using System;
using PaymentContext.Domain.ValueObject;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string BarCode,
        string BoletoNumber, 
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

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
