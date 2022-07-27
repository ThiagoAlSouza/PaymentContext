namespace PaymentContext.Domain.Entities;

public class Subscription
{
    private IList<Payment> payments;

    public Subscription(DateTime? expireDate)   
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpireDate = expireDate;
        Active = true;
        payments = new List<Payment>();
    }

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }

    public IReadOnlyCollection<Payment> Payments { get { return payments.ToArray(); } }

    public void AddPayment(Payment payment)
    {
        payments.Add(payment);
    }

    public void ActivateOrDeactivate(bool boolean)  
    {
        Active = boolean;
        LastUpdateDate = DateTime.Now;
    }
}