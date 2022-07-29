using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers;

public interface IHandler<T> where T : ICommand
{
    #region Assignatures

    ICommandResult Handle(T command);

    #endregion

}