namespace PaymentContext.Shared.Services;

public interface IEmailService
{
    #region Assignatures

    bool SendEmail(string to, string subject, string message);

    #endregion
}