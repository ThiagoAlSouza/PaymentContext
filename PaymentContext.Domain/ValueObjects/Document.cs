using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    #region Constructor

    public Document(string number, EDocumentType eDocumentType)
    {
        Number = number;
        EDocumentType = eDocumentType;
    }

    #endregion

    #region Properties

    public string Number { get; private set; }
    public EDocumentType EDocumentType { get; set; }

    #endregion
}