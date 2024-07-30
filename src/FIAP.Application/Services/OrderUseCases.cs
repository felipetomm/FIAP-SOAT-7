using FIAP.Application.Interfaces;
using FIAP.Domain.Interfaces.Repositories;
using FIAP.Infrastructure.CrossCutting.Interfaces;

namespace FIAP.Application.Services;

public partial class OrderUseCases : IOrderUseCases
{
    private readonly IOrdersRepository _repository;
    private readonly IProductsRepository _productsRepository;
    private readonly ICustomersRepository _customersRepository;
    private readonly IUnitOfWork _uow;
    public OrderUseCases(
        IOrdersRepository repository,
        IProductsRepository productsRepository,
        ICustomersRepository customersRepository,
        IUnitOfWork uow
    )
    {
        _repository = repository;
        _customersRepository = customersRepository;
        _productsRepository = productsRepository;
        _uow = uow;
    }
}