using FIAP.Application.Interfaces;
using FIAP.Domain.Interfaces.Repositories;

namespace FIAP.Application.Services;

public partial class OrderUseCases : IOrderUseCases
{
    protected readonly IOrdersRepository _repository;
    protected readonly IProductsRepository _productsRepository;
    protected readonly ICustomersRepository _customersRepository;
    public OrderUseCases(
        IOrdersRepository repository,
        IProductsRepository productsRepository,
        ICustomersRepository customersRepository
    )
    {
        _repository = repository;
        _customersRepository = customersRepository;
        _productsRepository = productsRepository;
    }
}