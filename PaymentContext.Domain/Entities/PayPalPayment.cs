namespace PaymentContext.Domain.Entities;

public class PayPalPayment : Payment
{
    public PayPalPayment(string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string document,
        string payer,
        string address,
        string transactionCode)
        : base(number, paidDate, expireDate, total, totalPaid, document, payer, address)
    {
        TransactionCode = transactionCode;
    }

    public string TransactionCode { get; private set; }
}