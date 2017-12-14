using PaymentContext.Domain.ValueObjects;
using Xunit;

namespace PaymentContext.Test.ValueObjects
{
    public class NameTest
    {
        [Fact]
        public void NomeValido()
        {
            Name name = new Name("Jose", "Silva");
            Assert.True(name.Valid);
        }

        [Theory]
        [InlineData("Jose", "")]
        [InlineData("JoseJoseJoseJoseJoseJoseJoseJoseJoseJoseJoseJoseJoseJoseJoseJose", "")]
        [InlineData("", "")]
        [InlineData("", "Silva")]
        public void NomeInvalido(string firstName, string lastName)
        {
            Name name = new Name(firstName, lastName);
            Assert.True(name.Invalid);
        }
    }
}