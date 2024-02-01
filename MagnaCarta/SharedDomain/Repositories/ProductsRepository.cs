using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedDomain.Data;
using SharedDomain.Entities;

namespace SharedDomain.Repositories;

public class ProductsRepository : IRepository<Product>
{
    private readonly ApplicationDbContext _dbContext;

    public ProductsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> CreateAsync(Product entity)
    {
        EntityEntry<Product> entityEntry = await _dbContext.Products.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(Product entity)
    {
        _dbContext.Products.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Product>> GetAllAsync()
    {
        return await _dbContext.Products
            .Include(p => p.Allergens)
            .ToArrayAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _dbContext.Products
            .Include(p => p.Allergens)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task DeleteAsync(int id)
    {
        Product entity = await _dbContext.Products.SingleAsync(p => p.Id == id);
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}