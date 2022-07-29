using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories;

public interface IStudentRepository
{
    #region Asignatures

    bool DocumentExist(string document);
    bool EmailExists(string email);
    void CreateSubscription(Student student);

    #endregion
}