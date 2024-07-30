using FIAP.Domain.Entities.Store;

namespace FIAP.Domain.Interfaces.Repositories;
public interface ICustomersRepository
{
    Task<Customers> SaveAsync(Customers customer);
    Task<Customers> FindByIdAsync(long id);
    Task<Customers> FindByCpfAsync(string cpf);
}