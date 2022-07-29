using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.MSTest.Tests.Mocks;

namespace PaymentContext.MSTest.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTest
{
    #region Methods

    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
        var command = new CreateBoletoSubscriptionCommand();
        command.FirstName = "Thiago";
        command.LastName = "Alves";
        command.Document = "123";
        command.Email = "thiagoalsouza98@outlook.com.br";
        command.BarCode = "7812375";
        command.BoletoNumber = "1923875";
        command.PaymentNumber = "1346";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddMonths(1);
        command.Total = 80;
        command.TotalPaid = 20;
        command.Payer = "Thiago";
        command.PayerDocument = "12345678911";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "thiagoalsouza98@outlook.com.br";
        command.Street = "Rua do joaozin";
        command.Number = "9";
        command.Neighborhood = "Vizinhaça";
        command.City = "Nova Iguaçu";
        command.State = "Rio de janeiro";
        command.Country = "Brasil";
        command.ZipCode = "12455-421";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
    }

    #endregion
}