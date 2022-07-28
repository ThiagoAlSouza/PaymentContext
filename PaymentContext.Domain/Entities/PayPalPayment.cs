using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class PayPalPayment : Payment
{
    #region Constructor

    public PayPalPayment(string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        Document document,
        string payer,
        Endereco address,
        string transactionCode,
        Email email)
        : base(number, paidDate, expireDate, total, totalPaid, document, payer, address, email)
    {
        TransactionCode = transactionCode;
    }

    #endregion

    #region Properties

    public string TransactionCode { get; private set; }

    #endregion
}