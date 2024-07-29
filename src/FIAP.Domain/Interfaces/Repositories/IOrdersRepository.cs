using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;

namespace FIAP.Domain.Interfaces.Repositories;
public interface IOrdersRepository
{
    Task<Orders> SaveAsync(Orders order);

    Task<List<Orders>> FindAllAsync();

    Task<Orders> FindById(long id);

    Task<List<Orders>> FindByStatusAsync(OrderStatus status);
}