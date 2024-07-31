using FIAP.Domain.Entities.Store;

namespace FIAP.Domain.Interfaces.Repositories;

public interface IPaymentsRepository
{
    Task<Payments> SaveAsync(Payments payment);
    Task<Payments> UpdateAsync(Payments payment);
    Task<Payments> FindByIdAsync(long id);
    Task<Payments> FindByExternalTransactionIdAsync(string externalTransactionId);
}