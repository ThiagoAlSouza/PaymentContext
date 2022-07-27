namespace PaymentContext.Domain.Entities;

public class PayPalPayment : Payment
{
    public string TransactionCode { get; set; }
}