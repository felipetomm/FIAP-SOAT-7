
using FIAP.Domain.Entities.Enums;
using FIAP.Domain.Entities.Store;
using FIAP.Domain.Interfaces.Repositories;

using Microsoft.EntityFrameworkCore;

namespace FIAP.Infrastructure.Data.Context.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly BaseDbContext _dbContext;
    public ProductsRepository(BaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task DeleteAsync(long id)
    {
        var product = await _dbContext.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (product == null)
            throw new Exception("Product not found");

        if (product.Deleted)
            throw new Exception("Product already deleted");

        _dbContext.Products.Remove(product);
    }

    public async Task<List<Products>> FindAllAsync()
    {
        return await _dbContext.Products.Where(x => !x.Deleted).ToListAsync();
    }

    public async Task<List<Products>> FindAllByCategoryAsync(Category category)
    {
        return await _dbContext.Products.Where(x => x.Category == category && !x.Deleted).ToListAsync();
    }

    public async Task<Products> FindByIdAsync(long id)
    {
        return await _dbContext.Products.Where(x => x.Id == id && !x.Deleted).FirstOrDefaultAsync();
    }

    public async Task<Products> SaveAsync(Products product)
    {
        product.Hash = Guid.NewGuid();
        product.Created = DateTime.Now;

        var newProduct = await _dbContext.Products.AddAsync(product);
        return newProduct.Entity;
    }

}