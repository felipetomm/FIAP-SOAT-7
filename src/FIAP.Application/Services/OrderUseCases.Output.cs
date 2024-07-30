using FIAP.Application.Interfaces;
using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;

namespace FIAP.Application.Services;

public partial class OrderUseCases
{
    public async Task<Orders> FindOrderAsync(long id)
    {
        return await _repository.FindByIdAsync(id);
    }
    public async Task<List<Orders>> FindOrderByStatusAsync(OrderStatus status)
    {
        return await _repository.FindByStatusAsync(status);
    }
}