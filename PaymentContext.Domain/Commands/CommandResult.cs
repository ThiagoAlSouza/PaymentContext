using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands;

public class CommandResult : ICommandResult
{
    #region Constructor

    public CommandResult() { }

    public CommandResult(bool sucess, string message)
    {
        Sucess = sucess;
        Message = message;
    }

    #endregion

    #region Properties

    public bool Sucess { get; set; }
    public string Message { get; set; }

    #endregion
}