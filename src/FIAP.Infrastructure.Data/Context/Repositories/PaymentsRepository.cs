
using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

namespace FIAP.Infrastructure.Data.Context.Repositories;

public class PaymentsRepository : IPaymentsRepository
{
    private readonly BaseDbContext _dbContext;
    public PaymentsRepository(BaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Payments> FindByIdAsync(long id)
    {
        return await _dbContext.Payments
            .Where(x => x.Id == id && !x.Deleted)
            .FirstOrDefaultAsync();
    }

    public async Task<Payments> FindByExternalTransactionIdAsync(string externalTransactionId)
    {
        return await _dbContext.Payments
            .Where(x => x.ExternalTransactionId == externalTransactionId && !x.Deleted)
            .FirstOrDefaultAsync();
    }

    public async Task<Payments> SaveAsync(Payments payment)
    {
        payment.Created = DateTime.Now;
        payment.Hash = Guid.NewGuid();
        payment.Deleted = false;

        var result = await _dbContext.Payments.AddAsync(payment);

        return result.Entity;
    }

    public async Task<Payments> UpdateAsync(Payments payment)
    {
        var currentRegistry = await _dbContext.Payments
            .Where(x => x.Id == payment.Id && !x.Deleted)
            .FirstOrDefaultAsync();

        if (currentRegistry == null)
            throw new ArgumentException("Domain object not found");

        payment.Modified = DateTime.Now;
        payment.Hash = Guid.NewGuid();

        _dbContext.Payments.Update(payment);

        return payment;
    }

}