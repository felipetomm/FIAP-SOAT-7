using FIAP.Application.Interfaces;
using FIAP.Domain.Entities.Store;

namespace FIAP.Application.Services;

public partial class OrderUseCases
{
    public async Task<Orders> CreateAsync(CreateOrderDto createOrderDto)
    {
        var combos = await CreateCombosAsync(createOrderDto.MappedCombos);

        var customer = createOrderDto.CustomerId != default
            ? await FindCustomerAsync(createOrderDto.CustomerId)
            : await FindDefaultCustomerAsync();

        return await _repository.SaveAsync(new Orders(
            combos: combos,
            customer: customer,
            status: Domain.Entities.Enums.OrderStatus.SENT_TO_KITCHEN
        ));
    }

    public async Task<Orders> UpdateOrderAsync(UpdateOrderDto updateOrderDto)
    {
        var order = await _repository.FindByIdAsync(updateOrderDto.Id);
        order.NextOrderStatus(updateOrderDto.Status);
        return await _repository.SaveAsync(order);
    }

    ///
    /// 
    /// PRIVATE METHODS
    /// 
    /// 

    private async Task<List<Combos>> CreateCombosAsync(List<CreateOrderDto.ComboDto> mappedCombos)
    {
        var combos = new List<Combos>();

        foreach (var combo in mappedCombos)
        {
            var comboItems = await CreateComboItemsAsync(combo.Items);
            combos.Add(
                new Combos(comboItems)
            );
        }

        return combos;
    }

    private async Task<List<ComboItems>> CreateComboItemsAsync(List<CreateOrderDto.ComboDto.ComboItemDto> map)
    {
        var comboItems = new List<ComboItems>();
        foreach (var item in map)
        {
            var product = await FindProductAsync(item.ProductId);
            comboItems.Add(new ComboItems(product, item.Quantity));
        }

        return comboItems;
    }

    private async Task<Products> FindProductAsync(long productId)
    {
        return await _productsRepository.FindByIdAsync(productId);
    }

    private async Task<Customers> FindCustomerAsync(long customerId)
    {
        return await _customersRepository.FindByIdAsync(customerId);
    }

    private async Task<Customers> FindDefaultCustomerAsync()
    {
        return await _customersRepository.FindByCpfAsync("00000000019");
    }
}