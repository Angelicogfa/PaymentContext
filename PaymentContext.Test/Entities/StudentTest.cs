using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
using Xunit;

namespace PaymentContext.Test.Entities
{
    public class StudentTest
    {
        Name _name;
        Address _address;
        Email _email;
        Document _document;
        Student _student;
        Subscription _subscription;

        public StudentTest()
        {
            _name = new Name("Bruce", "Wayne");
            _email = new Email("batman@dc.com");
            _address = new Address("Rua 1", "123", "Bairro DC", "Gothan", "DC", "USA", "123");
            _document = new Document("35111507795", EDocumentType.CPF);
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
        }

        [Fact]
        public void AdicionarAssinaturaValida()
        {
            var payment = new PayPalPayment(Guid.NewGuid().ToString("n"), DateTime.Now, DateTime.Now.AddDays(3), 10, 10, "Curringa", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.True(_student.Valid);
            Assert.True(_subscription.Valid);
            Assert.True(payment.Valid);
            Assert.Contains(_subscription, _student.Subscriptions);
            Assert.Contains(payment, _subscription.Payments);
        }

        [Fact]
        public void AdicionarAssinaturaInvalida_NaoExistePagamento()
        {
            _student.AddSubscription(_subscription);
            Assert.True(_student.Invalid);
            Assert.True(_subscription.Valid);
            Assert.True(_student.Subscriptions.Count == 0);
        }

        [Fact]
        public void AdicionarAssinaturaInvalida_PagamentoInvalidoValorPago()
        {
            var payment = new PayPalPayment(Guid.NewGuid().ToString("n"), DateTime.Now, DateTime.Now.AddDays(3), 10, 9, "Curringa", _document, _address, _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.True(payment.Invalid);
            Assert.True(_subscription.Invalid);
            
            Assert.DoesNotContain(_subscription, _student.Subscriptions);
            Assert.DoesNotContain(payment, _subscription.Payments);
        }

        [Fact]
        public void AdicionarAssinaturaInvalida_ExistenciaSubscription()
        {
            var payment = new PayPalPayment(Guid.NewGuid().ToString("n"), DateTime.Now, DateTime.Now.AddDays(3), 10, 10, "Curringa", _document, _address, _email);
            _subscription.AddPayment(payment);

            _student.AddSubscription(_subscription);
            Assert.True(_student.Valid);
            Assert.True(_student.Subscriptions.Count == 1);

            var _subscription2 = new Subscription(null);
            var payment2 = new PayPalPayment(Guid.NewGuid().ToString("n"), DateTime.Now, DateTime.Now.AddDays(3), 10, 10, "Curringa", _document, _address, _email);
            _subscription2.AddPayment(payment2);

            _student.AddSubscription(_subscription2);
            Assert.True(_student.Invalid);
            Assert.True(_student.Subscriptions.Count == 1);
        }
    }
}
