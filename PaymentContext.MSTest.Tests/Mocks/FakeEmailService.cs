using PaymentContext.Shared.Services;

namespace PaymentContext.MSTest.Tests.Mocks;

public class FakeEmailService : IEmailService
{
    #region Methods

    public bool SendEmail(string to, string subject, string message)
    {
        return true;
    }

    #endregion
}