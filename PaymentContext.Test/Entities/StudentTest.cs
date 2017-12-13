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
            Student student = new Student("Jose", "Silva", "123.456.789-96", "jose_silva@gmail.com");
        }
    }
}
