using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.MSTest.Tests.Entities;

[TestClass]
public class StudentTest
{
    #region Private

    private readonly Name _name;
    private readonly Endereco _endereco;
    private readonly Email _email;
    private readonly Document _document;
    private readonly Payment _payment;
    private readonly Student _student;
    private readonly Subscription _subscription;

    #endregion

    #region Constructor

    public StudentTest()
    {
        _name = new Name("Thiago", "Alves");
        _document = new Document("28371282734", EDocumentType.CPF);
        _email = new Email("thiagoalsouza98@outlook.com.br");
        _endereco = new Endereco("Rua do joaozin", "90", "vizinhaça", "Nova Iguaçu", "Rio de Janeiro", "Brasil", "8271673");
        _student = new Student(_name, _document, _email, _endereco);
        _payment = new PayPalPayment("1278312", DateTime.Now, DateTime.MaxValue, 60, 60, _document, "Thiago", _endereco, "JHASF0128NADS92", _email);
        _subscription = new Subscription(null);

        _subscription.AddPayment(_payment);
    }

    #endregion

    #region Methods

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    #endregion
}