using System;
using PaymentContext.Domain.Entities;
using Xunit;

namespace PaymentContext.Test
{
    public class StudentTest
    {
        [Fact]
        public void Test1()
        {
            Subscription subscription = new Subscription(null);
            Student student = new Student("Jose", "Silva", "123.456.789-96", "jose_silva@gmail.com");

            student.AddSubscription(subscription);
        }
    }
}
