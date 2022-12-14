using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    #region Constructor

    public CreditCardPayment(
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        Document document,
        string payer,
        Address address,
        string cardHolderName,
        string cardNumber,
        string lastTransactionNumber,
        Email email)
        : base(paidDate, expireDate, total, totalPaid, document, payer, address, email)
    {
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    #endregion

    #region Properties

    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
    public string LastTransactionNumber { get; private set; }

    #endregion
}