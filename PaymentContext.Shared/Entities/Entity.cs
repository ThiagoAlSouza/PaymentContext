using Flunt.Notifications;

namespace PaymentContext.Shared.Entities;
public abstract class Entity : Notifiable<Notification> 
{
    #region Constructor

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    #endregion

    #region Properties

    public Guid Id { get; set; }

    #endregion
}