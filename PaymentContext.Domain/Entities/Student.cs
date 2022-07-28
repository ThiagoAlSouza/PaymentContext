using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    #region Private

    private IList<Subscription> subscriptions;

    #endregion

    #region Constructor

    public Student(Name name, Document document, Email email, Endereco address)
    {
        Name = name;
        Document = document;
        Email = email;
        Address = address;
        subscriptions = new List<Subscription>();

       //AddNotification(name, document, email);
    }

    #endregion

    #region Properties

    public Name Name { get; private set; }
    public Document Document { get; private set; }
    public Email Email { get; private set; }    
    public Endereco Address { get; private set; }

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