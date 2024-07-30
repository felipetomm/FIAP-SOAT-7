
using FIAP.Application.Interfaces;
using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;

namespace FIAP.Application.Services;

public class CustomerUseCases : ICustomerUseCases
{
    private readonly ICustomersRepository _repository;
    public CustomerUseCases(ICustomersRepository repository)
    {
        _repository = repository;
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

        return await _repository.SaveAsync(customer);
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