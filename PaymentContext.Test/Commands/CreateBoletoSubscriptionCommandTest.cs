using PaymentContext.Domain.Commands;
using Xunit;

namespace PaymentContext.Test.Commands
{
    public class CreateBoletoSubscriptionCommandTest
    {
        [Fact]
        public void PodeRetornarErroQuantoNomeEstaInvalido()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";
            command.LastName = "";

            command.Validate();
            Assert.False(command.Valid);
        }
    }
}