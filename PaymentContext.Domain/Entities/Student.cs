using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class Student
{
    #region Private

    private IList<Subscription> subscriptions;

    #endregion

    #region Constructor

    public Student(Name name, string document, Email email)
    {
        Name = name,
        Document = document;
        Email = email;
        subscriptions = new List<Subscription>();
    }

    #endregion

    #region Properties

    public Name Name { get; private set; }
    public string Document { get; private set; }
    public Email Email { get; private set; }    
    public string Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions { get { return subscriptions.ToArray(); } }

    #endregion

    #region Methods

    public void AddSubscription(Subscription subscription)
    {
        subscription.ActivateOrDeactivate(true);

        foreach (var item in Subscriptions)
        {
            item.ActivateOrDeactivate(false);
        }

        subscriptions.Add(subscription);
    }

    #endregion
}