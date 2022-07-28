using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    #region Constructor

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    #endregion

    #region Properties

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    #endregion
}