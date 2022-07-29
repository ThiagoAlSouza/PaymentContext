namespace PaymentContext.Shared.Services;

public interface IEmailService
{
    bool SendEmail(string to, string subject, string message);
}