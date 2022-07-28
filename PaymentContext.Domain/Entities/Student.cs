using Flunt.Notifications;
using Flunt.Validations;
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

       AddNotifications(name, document, email);
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
        var hasSubscriptionActive = false;

        foreach (var item in Subscriptions)
        {
            if (item.Active)
                hasSubscriptionActive = true;
        }

        AddNotifications(new Contract<Notification>()
            .Requires()
            .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
            .IsLowerThan(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
        );

        if(IsValid)
            subscriptions.Add(subscription);
    }

    public bool VerifiedHadActiveSubscription()
    {
        foreach (var item in Subscriptions)
        {
            if (item.Active)
                return true;
        }

        return false;
    }

    #endregion
}