using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;

namespace FIAP.Application.Interfaces;

public interface IProductUseCases
{
    Task<Products> CreateProductAsync(Products product);

    Task DeleteProductAsync(long id);

    Task<Products> UpdateProductAsync(Products product);

    Task<List<Products>> FindProductsAsync();

    Task<List<Products>> FindProductsByCategoryAsync(Category category);
}