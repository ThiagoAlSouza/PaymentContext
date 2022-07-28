using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.MSTest.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("124562", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.Validate());
    }

    [TestMethod]
    public void ShouldReturnSucessWhenCNPJIsValid()
    {
        var doc = new Document("12345678910234", EDocumentType.CNPJ);
        Assert.IsTrue(doc.Validate());
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("124562", EDocumentType.CPF);
        Assert.IsTrue(!doc.Validate());
    }

    [TestMethod]
    public void ShouldReturnSucessWhenCPFIsInvalid()    
    {
        var doc = new Document("83345234134", EDocumentType.CPF);
        Assert.IsTrue(doc.Validate());
    }
}