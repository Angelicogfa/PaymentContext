using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;
using Xunit;

namespace PaymentContext.Test.Entities
{
    public class StudentTest
    {
        [Fact]
        public void AdicionarAssinaturaValida()
        {
            Subscription subscription = new Subscription(null);

            Address endereco = new Address("RUA DOS CARVALHOS", "S/N", "", "METROCITY", "CA", "USA", "123");

            subscription.AddPayment(new PayPalPayment(Guid.NewGuid().ToString("n"),
            DateTime.Now, 
            DateTime.Now.AddDays(2), 
            10, 
            10, 
            "Maria",
            new Document("12.852.369/8521-08", EDocumentType.CNPJ), endereco, 
            new Email("maria@gmail.com")));

            Student student = new Student(new Name("Jose", "Silva"), new Document("123.456.789-96", EDocumentType.CPF), new Email("jose_silva@gmail.com"));

            student.AddSubscription(subscription);

            Assert.True(student.Valid);
            Assert.True(subscription.Valid);
            Assert.Contains(subscription, student.Subscriptions);
        }

        [Fact]
        public void AdicionarAssinaturaInvalida_NaoExistePagamento()
        {
            Student student = new Student(new Name("Jose", "Silva"), new Document("123.456.789-96", EDocumentType.CPF), new Email("jose_silva@gmail.com"));

            Address endereco = new Address("RUA DOS CARVALHOS", "S/N", "", "METROCITY", "CA", "USA", "123");
            Subscription subscription01 = new Subscription(null);

            student.AddSubscription(subscription01);
            Assert.True(student.Invalid);
            Assert.True(student.Subscriptions.Count == 0);
        }

        [Fact]
        public void AdicionarAssinaturaInvalida_PagamentoInvalidoValorPago()
        {
            Subscription subscription = new Subscription(null);

            Address endereco = new Address("RUA DOS CARVALHOS", "S/N", "", "METROCITY", "CA", "USA", "123");
            var pagamento = new PayPalPayment(Guid.NewGuid().ToString("n"),
            DateTime.Now,
            DateTime.Now.AddDays(2),
            10,
            9.5M,
            "Maria",
            new Document("12.852.369/8521-08", EDocumentType.CNPJ), endereco,
            new Email("maria@gmail.com"));

            subscription.AddPayment(pagamento);

            Student student = new Student(new Name("Jose", "Silva"), new Document("123.456.789-96", EDocumentType.CPF), new Email("jose_silva@gmail.com"));

            student.AddSubscription(subscription);

            Assert.True(pagamento.Invalid);
            Assert.True(subscription.Invalid);
            Assert.True(student.Invalid);
            
            Assert.DoesNotContain(subscription, student.Subscriptions);
            Assert.DoesNotContain(pagamento, subscription.Payments);
        }

        [Fact]
        public void AdicionarAssinaturaInvalida_ExistenciaSubscription()
        {
            Student student = new Student(new Name("Jose", "Silva"), new Document("123.456.789-96", EDocumentType.CPF), new Email("jose_silva@gmail.com"));

            Address endereco = new Address("RUA DOS CARVALHOS", "S/N", "", "METROCITY", "CA", "USA", "123");
            
            Subscription subscription01 = new Subscription(null);
            subscription01.AddPayment(new PayPalPayment(Guid.NewGuid().ToString("n"),
            DateTime.Now, 
            DateTime.Now, 
            10, 
            10, 
            "Maria",
            new Document("12.852.369/8521-08", EDocumentType.CNPJ), endereco, 
            new Email("maria@gmail.com")));

            Subscription subscription02 = new Subscription(null);
            subscription02.AddPayment(new PayPalPayment(Guid.NewGuid().ToString("n"),
            DateTime.Now, 
            DateTime.Now.AddDays(2), 
            10, 
            10, 
            "Maria",
            new Document("12.852.369/8521-08", EDocumentType.CNPJ), endereco, 
            new Email("maria@gmail.com")));

            student.AddSubscription(subscription01);
            Assert.True(student.Valid);
            Assert.True(student.Subscriptions.Count == 1);

            student.AddSubscription(subscription02);
            Assert.True(student.Invalid);
            Assert.True(student.Subscriptions.Count == 1);
        }
    }
}
