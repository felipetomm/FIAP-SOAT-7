
using FIAP.Application.Interfaces;
using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;
using FIAP.Infrastructure.CrossCutting.Interfaces;

namespace FIAP.Application.Services;

public class ProductUseCases : IProductUseCases
{
    private readonly IProductsRepository _repository;
    private readonly IUnitOfWork _uow;

    public ProductUseCases(
        IProductsRepository repository,
        IUnitOfWork uow
    )
    {
        _repository = repository;
        _uow = uow;
    }
    public async Task<Products> CreateProductAsync(Products product)
    {
        var result = await _repository.SaveAsync(product);

        await _uow.CommitAsync();

        return result;
    }

    public async Task DeleteProductAsync(long id)
    {
        await _repository.DeleteAsync(id);
        await _uow.CommitAsync();
    }

    public async Task<Products> UpdateProductAsync(Products product)
    {
        var result = await _repository.SaveAsync(product);

        await _uow.CommitAsync();

        return result;
    }

    public async Task<List<Products>> FindProductsAsync()
    {
        return await _repository.FindAllAsync();
    }

    public async Task<List<Products>> FindProductsByCategoryAsync(Category category)
    {
        return await _repository.FindAllByCategoryAsync(category);
    }

}