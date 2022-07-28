namespace PaymentContext.Domain.ValueObjects;

public class Name
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