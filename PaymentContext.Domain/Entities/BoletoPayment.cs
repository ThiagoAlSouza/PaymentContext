namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    #region Constructor

    public BoletoPayment(string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string document,
        string payer,
        string address,
        string barCode,
        string boletoNumber)
        : base(number, paidDate, expireDate, total, totalPaid, document, payer, address)
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