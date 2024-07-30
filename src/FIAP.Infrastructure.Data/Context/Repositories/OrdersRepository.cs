
using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

namespace FIAP.Infrastructure.Data.Context.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly BaseDbContext _dbContext;
    public OrdersRepository(BaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Orders>> FindAllAsync()
    {
        return await _dbContext.Orders.Where(x => !x.Deleted).ToListAsync();
    }

    public async Task<Orders> FindByIdAsync(long id)
    {
        return await _dbContext.Orders.Where(x => x.Id == id && !x.Deleted).FirstOrDefaultAsync();
    }

    public async Task<List<Orders>> FindByStatusAsync(OrderStatus status)
    {
        return await _dbContext.Orders.Where(x => x.Status == status && !x.Deleted).ToListAsync();
    }

    public async Task<Orders> SaveAsync(Orders order)
    {
        order.Hash = Guid.NewGuid();
        order.Created = DateTime.Now;

        var newOrder = await _dbContext.Orders.AddAsync(order);
        return newOrder.Entity;
    }

}