using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
        }

        public CommandResult()
        {
            
        }

        public bool Sucess { get; set; }
        public string Message { get; set; }
    }
}