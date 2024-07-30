using FIAP.Domain.Entities.Store;

namespace FIAP.Application.Interfaces;

public interface ICustomerUseCases
{
    /// <summary>
    /// Create new customer
    /// </summary>
    /// <param name="customer">Customer object</param>
    /// <returns></returns>
    Task<Customers> CreateCustomerAsync(Customers customer);

    /// <summary>
    /// Find customer by CPF
    /// </summary>
    /// <param name="cpf">Brazilian CPF</param>
    /// <returns></returns>
    Task<Customers> FindByCpfAsync(string cpf);
}