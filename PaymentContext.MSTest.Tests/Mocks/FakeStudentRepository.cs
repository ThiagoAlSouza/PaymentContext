using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.MSTest.Tests.Mocks;

public class FakeStudentRepository : IStudentRepository
{
    #region Methods

    public bool DocumentExist(string document)
    {
        if (document.Equals("123"))
            return true;

        return false;
    }

    public bool EmailExists(string email)
    {
        if (email.Equals("thiagoalsouza98@outlook.com.br"))
            return true;

        return false;
    }

    public void CreateSubscription(Student student)
    {

    }

    #endregion
}