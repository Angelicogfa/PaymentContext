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
            Student student = new Student(new Name("Jose", "Silva"), new Document("123.456.789-96", EDocumentType.CPF), new Email("jose_silva@gmail.com"));

            student.AddSubscription(subscription);

            Assert.True(student.Valid);
            Assert.True(subscription.Valid);
            Assert.Contains(subscription, student.Subscriptions);
        }

        [Fact]
        public void AdicionarAssinaturaInvalida_ExistenciaSubscription()
        {
            Student student = new Student(new Name("Jose", "Silva"), new Document("123.456.789-96", EDocumentType.CPF), new Email("jose_silva@gmail.com"));

            student.AddSubscription(new Subscription(null));
            Assert.True(student.Valid);
            Assert.True(student.Subscriptions.Count == 1);

            student.AddSubscription(new Subscription(null));
            Assert.True(student.Invalid);
            Assert.True(student.Subscriptions.Count == 1);
        }
    }
}
