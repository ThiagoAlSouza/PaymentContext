using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Subscription : Entity
{
    #region Private

    private IList<Payment> payments;

    #endregion

    #region Constructor

    public Subscription(DateTime? expireDate)
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpireDate = expireDate;
        Active = true;
        payments = new List<Payment>();
    }

    #endregion

    #region Properties

    public DateTime CreateDate { get; private set; }
    public DateTime LastUpdateDate { get; private set; }
    public DateTime? ExpireDate { get; private set; }
    public bool Active { get; private set; }

    public IReadOnlyCollection<Payment> Payments { get { return payments.ToArray(); } }

    #endregion

    #region Methods

    public void AddPayment(Payment payment)
    {
        payments.Add(payment);
    }

    public void ActivateOrDeactivate(bool boolean)
    {
        Active = boolean;
        LastUpdateDate = DateTime.Now;
    }

    #endregion
}