
using FIAP.Application.Interfaces;
using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;

namespace FIAP.Application.Services;

public class ProductUseCases : IProductUseCases
{
    private readonly IProductsRepository _repository;

    public ProductUseCases(IProductsRepository repository)
    {
        _repository = repository;
    }
    public async Task<Products> CreateProductAsync(Products product)
    {
        return await _repository.SaveAsync(product);
    }

    public async Task DeleteProductAsync(long id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<Products> UpdateProductAsync(Products product)
    {
        return await _repository.SaveAsync(product);
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