using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Email : ValueObject
{
    #region Contructor

    public Email(string address)
    {
        Address = address;
    }

    #endregion

    #region Properties

    public string Address { get; private set; }

    #endregion
}