using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using PaymentContext.Shared.Services;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>, IHandler<CreatePayPalSubscriptionCommand>
{
    #region Private

    private readonly IStudentRepository _repository;
    private readonly IEmailService _emailService;

    #endregion

    #region Constructor

    public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    #endregion

    #region Methods

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        if (_repository.DocumentExist(command.Document))
            AddNotification("Document", "Este Documento já está em uso");

        if (_repository.EmailExists(command.Email))
            AddNotification("Email", "Este E-mail já está em uso");

        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State,
            command.Country, command.ZipCode);

        var student = new Student(name, document, email, address);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));
        var payment = new BoletoPayment(
            command.BarCode,
            command.BoletoNumber,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            new Document(command.PayerDocument, command.PayerDocumentType),
            address,
            email
        );

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(name, document, email, address, student, subscription, payment);

        if (IsValid)
            return new CommandResult(false, "Não foi possível realizar sua assinatura");

        _repository.CreateSubscription(student);

        _emailService.SendEmail(student.Name.ToString(), "bem vindo ao balta.io", "Sua assinatura foi criada");

        return new CommandResult(true, "Assinatura realizada com sucesso");
    }

    public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
    {
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, "Não foi possível realizar sua assinatura");
        }

        if (_repository.DocumentExist(command.Document))
            AddNotification("Document", "Este CPF já está em uso");

        if (_repository.EmailExists(command.Email))
            AddNotification("Email", "Este E-mail já está em uso");

        var name = new Name(command.FirstName, command.LastName);
        var document = new Document(command.Document, EDocumentType.CPF);
        var email = new Email(command.Email);
        var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State,
            command.Country, command.ZipCode);


        var student = new Student(name, document, email, address);
        var subscription = new Subscription(DateTime.Now.AddMonths(1));

        var payment = new PayPalPayment(
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            new Document(command.PayerDocument, command.PayerDocumentType),
            command.Payer,
            address,
            command.TransactionCode,
            email
        );

        subscription.AddPayment(payment);
        student.AddSubscription(subscription);

        AddNotifications(name, document, email, address, student, subscription, payment);

        _repository.CreateSubscription(student);

        _emailService.SendEmail(student.Name.ToString(), "bem vindo ao balta.io", "Sua assinatura foi criada");

        return new CommandResult(true, "Assinatura realizada com sucesso");
    }

    #endregion
}