using FIAP.Domain.Entities.Base;
using FIAP.Infrastructure.CrossCutting.Extensions;

namespace FIAP.Domain.Entities.Store;

public class Customers : EntityBaseSoft<long>
{
    public string Name { get; private set; }
    public string Cpf { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    protected Customers() { }

    public Customers(
        long? id,
        string name,
        string email,
        string phone,
        string cpf
    )
    {
        var validationResult = Validate(
            name: name,
            email: email,
            phone: phone,
            cpf: cpf
        );

        if (!validationResult.IsValid())
            throw new ArgumentException(validationResult.GetErrorsMessage());

        if (id.HasValue)
            Id = id.Value;
        Name = name;
        Email = email;
        Phone = phone;
        Cpf = cpf.OnlyDigits();
        Created = DateTime.UtcNow;
        Deleted = false;
        Hash = Guid.NewGuid();
    }

    private DomainValidationResult Validate(
        string name,
        string email,
        string phone,
        string cpf
    )
    {
        var validationResult = new DomainValidationResult();

        if (name.IsEmpty())
            validationResult.AddError("Name is required");

        if ((cpf.IsEmpty(numberOnly: true) || !cpf.IsValidCPF()) && !cpf.OnlyDigits().Equals("00000000019"))
            validationResult.AddError("CPF is empty ir invalid");

        if (email.IsEmpty() && phone.IsEmpty())
            validationResult.AddError("E-mail or Phone is required");

        return validationResult;
    }
}