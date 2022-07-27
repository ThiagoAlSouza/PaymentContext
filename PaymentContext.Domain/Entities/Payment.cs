namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
    protected Payment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string document, string payer, string address)
    {
        Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Document = document;
        Payer = payer;
        Address = address;
    }

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }  
    public decimal TotalPaid { get; private set; }
    public string Document { get; private set; }
    public string Payer { get; private set; }
    public string Address { get; private set; }
}