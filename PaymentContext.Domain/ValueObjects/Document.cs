using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    #region Constructor

    public Document(string number, EDocumentType eDocumentType)
    {
        Number = number;
        DocumentType = eDocumentType;

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsTrue(Validate(), "Document.Number", $"{DocumentType.ToString()} is not valid.")
        );
    }

    #endregion

    #region Properties

    public string Number { get; private set; }
    public EDocumentType DocumentType { get; set; }

    #endregion

    #region Methods

    public bool Validate()
    {
        if (DocumentType == EDocumentType.CPF && Number.Length == 11)
            return true;
        
        if (DocumentType == EDocumentType.CNPJ && Number.Length == 14)
            return true;

        return false;
    }

    #endregion
}