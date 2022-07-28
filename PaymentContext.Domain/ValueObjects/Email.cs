using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    #region Properties

    public string Address { get; set; }

    #endregion
}