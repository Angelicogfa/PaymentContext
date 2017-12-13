using System;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, string document, string address, string email) : base(paidDate, expireDate, total, totalPaid, payer, document, address, email)
        {
        }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
    }
}
