using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity
{
    #region Constructor

    protected Payment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Document document, string payer, Address address, Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Document = document;
        Payer = payer;
        Address = address;
        Email = email;
    }

    #endregion

    #region Properties

    public string Number { get; private set; }
    public DateTime PaidDate { get; private set; }
    public DateTime ExpireDate { get; private set; }
    public decimal Total { get; private set; }
    public decimal TotalPaid { get; private set; }
    public Document Document { get; private set; }
    public string Payer { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; set; }

    #endregion
}