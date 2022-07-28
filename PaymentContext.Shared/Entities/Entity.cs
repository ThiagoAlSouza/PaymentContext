namespace PaymentContext.Shared.Entities;
public abstract class Entity
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