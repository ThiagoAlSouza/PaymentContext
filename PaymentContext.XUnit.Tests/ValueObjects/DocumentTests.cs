using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.XUnit.Tests.ValueObjects;

public class DocumentTests
{
    [Fact]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("124562", EDocumentType.CNPJ);
        Assert.True(!doc.IsValid);
    }

    [Fact]
    public void ShouldReturnSucessWhenCNPJIsValid()
    {
        var doc = new Document("12345678910234", EDocumentType.CNPJ);
        Assert.True(doc.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("124562", EDocumentType.CPF);
        Assert.True(!doc.IsValid);
    }

    [Fact]
    public void ShouldReturnSucessWhenCPFIsInvalid()
    {
        var doc = new Document("83345234134", EDocumentType.CPF);
        Assert.True(doc.IsValid);
    }
}