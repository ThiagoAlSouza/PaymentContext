using PaymentContext.Domain.Commands;

namespace PaymentContext.MSTest.Tests.Commands;

[TestClass]
public class CreateBoletoSubscriptionCommandTest
{
    [TestMethod]
    public void ShouldReturnErrorWhenNameIsInvalid()
    {
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Th";

        command.Validate();

        Assert.IsTrue(!command.IsValid);
    }
}