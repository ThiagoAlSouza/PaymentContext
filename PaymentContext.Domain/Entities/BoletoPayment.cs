using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    #region Constructor

    public BoletoPayment(
        string barCode,
        string boletoNumber,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        Document document,
        Address address,
        Email email)
        : base(paidDate, expireDate, total, totalPaid, document, payer, address, email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }

    #endregion

    #region Properties

    public string BarCode { get; private set; }
    public string BoletoNumber { get; private set; }

    #endregion
}