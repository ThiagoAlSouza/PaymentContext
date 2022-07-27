﻿namespace PaymentContext.Domain.Entities;

public class Student
{
    private IList<Subscription> subscriptions;

    public Student(string firstName, string lastName, string document, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        Email = email;
        subscriptions = new List<Subscription>();
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Document { get; private set; }
    public string Email { get; private set; }
    public string Address { get; private set; }

    public IReadOnlyCollection<Subscription> Subscriptions { get { return subscriptions.ToArray(); } }

    public void AddSubscription(Subscription subscription)
    {
        subscription.ActivateOrDeactivate(true);

        foreach (var item in Subscriptions)
        {
            item.ActivateOrDeactivate(false);
        }

        subscriptions.Add(subscription);
    }
}