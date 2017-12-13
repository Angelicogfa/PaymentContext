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
        public void AdicionarAssinatura()
        {
            Subscription subscription = new Subscription(null);
            Student student = new Student(new Name("Jose", "Silva"), new Document("123.456.789-96", EDocumentType.CPF), new Email("jose_silva@gmail.com"));

            student.AddSubscription(subscription);

            Assert.True(student.Valid);
            Assert.True(subscription.Valid);
            Assert.Contains(subscription, student.Subscriptions);
        }
    }
}
