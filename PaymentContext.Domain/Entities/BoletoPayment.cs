using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    #region Constructor

    public BoletoPayment(string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        Document document,
        string payer,
        string address,
        string barCode,
        string boletoNumber,
        Email email)
        : base(number, paidDate, expireDate, total, totalPaid, document, payer, address, email)
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