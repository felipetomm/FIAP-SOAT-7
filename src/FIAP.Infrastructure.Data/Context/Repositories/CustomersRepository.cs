
using System.Runtime.CompilerServices;

using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

namespace FIAP.Infrastructure.Data.Context.Repositories;

public class CustomersRepository : ICustomersRepository
{
    private readonly BaseDbContext _dbContext;
    public CustomersRepository(BaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Customers> FindByCpfAsync(string cpf)
    {
        return await _dbContext.Customers.Where(x => x.Cpf == cpf && !x.Deleted).FirstOrDefaultAsync();
    }

    public async Task<Customers> FindByIdAsync(long id)
    {
        return await _dbContext.Customers.Where(x => x.Id == id && !x.Deleted).FirstOrDefaultAsync();
    }

    public async Task<Customers> SaveAsync(Customers customer)
    {
        customer.Hash = Guid.NewGuid();
        customer.Created = DateTime.Now;

        var newCustomer = await _dbContext.Customers.AddAsync(customer);

        return newCustomer.Entity;
    }
}