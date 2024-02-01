using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedDomain.Data;
using SharedDomain.Entities;

namespace SharedDomain.Repositories;

public class AllergensRepository : IRepository<Allergen>
{
    private readonly ApplicationDbContext _dbContext;

    public AllergensRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Allergen> CreateAsync(Allergen entity)
    {
        EntityEntry<Allergen> entityEntry = await _dbContext.Allergens.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(Allergen entity)
    {
        _dbContext.Allergens.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Allergen>> GetAllAsync()
    {
        return await _dbContext.Allergens
            .ToArrayAsync();
    }

    public async Task<Allergen?> GetByIdAsync(int id)
    {
        return await _dbContext.Allergens
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task DeleteAsync(int id)
    {
        Order entity = await _dbContext.Orders.SingleAsync(p => p.Id == id);
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}