
using FIAP.Application.Interfaces;
using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;
using FIAP.Infrastructure.CrossCutting.Interfaces;

namespace FIAP.Application.Services;

public class CustomerUseCases : ICustomerUseCases
{
    private readonly ICustomersRepository _repository;
    private readonly IUnitOfWork _uow;
    public CustomerUseCases(
        ICustomersRepository repository,
        IUnitOfWork uow
    )
    {
        _repository = repository;
        _uow = uow;
    }

    /// <summary>
    /// Create new customer
    /// </summary>
    /// <param name="customer">Customer object</param>
    /// <returns></returns>
    public async Task<Customers> CreateCustomerAsync(Customers customer)
    {
        var optExistingCustomer = await _repository.FindByCpfAsync(customer.Cpf);
        if (optExistingCustomer?.Id != default)
            return optExistingCustomer;

        var result = await _repository.SaveAsync(customer);

        await _uow.CommitAsync();

        return result;
    }

    /// <summary>
    /// Find customer by CPF
    /// </summary>
    /// <param name="cpf">Brazilian CPF</param>
    /// <returns></returns>
    public async Task<Customers> FindByCpfAsync(string cpf)
    {
        return await _repository.FindByCpfAsync(cpf);
    }
}