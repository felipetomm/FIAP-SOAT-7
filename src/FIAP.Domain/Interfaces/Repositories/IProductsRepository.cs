using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;

namespace FIAP.Domain.Interfaces.Repositories;

public interface IProductsRepository
{
    Task<Products> SaveAsync(Products product);

    Task<List<Products>> FindAllAsync();

    Task DeleteAsync(long id);

    Task<List<Products>> FindAllByCategoryAsync(Category category);

    Task<Products> FindByIdAsync(long id);
}