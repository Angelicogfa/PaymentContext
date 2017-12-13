using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObject;
using PaymentContext.Domain.Enums;
using Xunit;

namespace PaymentContext.Test
{
    public class StudentTest
    {
        [Fact]
        public void Test1()
        {
            Subscription subscription = new Subscription(null);
            var name = new Name("Jose", "Silva");
            var document = new Document("123.456.789-96", EDocumentType.CPF);
            Student student = new Student(name, document, "jose_silva@gmail.com");

            student.AddSubscription(subscription);
        }
    }
}
