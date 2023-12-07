using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedDomain.Data;
using SharedDomain.Entities;

namespace SharedDomain.Repositories;

public class TablesRepository : IRepository<Table>
{
    private readonly ApplicationDbContext _dbContext;

    public TablesRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Table> CreateAsync(Table entity)
    {
        EntityEntry<Table> entityEntry = await _dbContext.Tables.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(Table entity)
    {
        _dbContext.Tables.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Table>> GetAllAsync()
    {
        return await _dbContext.Tables.ToArrayAsync();
    }

    public async Task<Table?> GetByIdAsync(int id)
    {
        return await _dbContext.Tables
            .Include(t => t.Orders)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task DeleteAsync(int id)
    {
        Table entity = await _dbContext.Tables.SingleAsync(p => p.Id == id);
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}