using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;

namespace FIAP.Application.Interfaces;

public interface IOrderUseCases
{
    Task<Orders> CreateAsync(CreateOrderDto createOrderDto);

    Task<Orders> UpdateOrderAsync(UpdateOrderDto updateOrderDto);

    Task<Orders> FindOrderAsync(long id);

    Task<List<Orders>> FindAllOrdersAsync();

    Task<List<Orders>> FindOrderByStatusAsync(OrderStatus status);
}

public class CreateOrderDto
{
    public List<ComboDto> MappedCombos { get; set; }
    public long CustomerId { get; set; }

    public class ComboDto
    {
        public List<ComboItemDto> Items { get; set; }

        public class ComboItemDto
        {
            public long ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}

public class UpdateOrderDto
{
    public long Id { get; set; }
    public OrderStatus Status { get; set; }
}