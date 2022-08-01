using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.XUnit.Tests.ValueObjects;

public class DocumentTests
{
    #region Methods

    [Theory]
    [InlineData("387147")]
    [InlineData("387147662")]
    [InlineData("3871477345")]
    [InlineData("38714756")]
    [InlineData("9738714745747")]
    public void ShouldReturnErrorWhenCNPJIsInvalid(string cnpj)
    {
        var doc = new Document(cnpj, EDocumentType.CNPJ);
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

    #endregion
}