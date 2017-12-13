using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.ValueObjects
{
    public class EmailTest
    {
        [Fact]
        public void EmailValido()
        {
            Email email = new Email("jose_silva@gmail.com");

            Assert.True(email.Valid);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("jose@.com")]
        [InlineData("@google.com")]
        [InlineData("@.com")]
        [InlineData("@google")]
        [InlineData("jose.com")]
        [InlineData("jose@")]
        [InlineData("jose@google")]
        public void EmailInvalido(string emailAddress)
        {
            Email mail = new Email(emailAddress);

            Assert.True(mail.Invalid);
        }
    }    
}