using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedDomain.Data;
using SharedDomain.Entities;

namespace SharedDomain.Repositories;

public class OrdersRepository : IRepository<Order>
{
    private readonly ApplicationDbContext _dbContext;

    public OrdersRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> CreateAsync(Order entity)
    {
        EntityEntry<Order> entityEntry = await _dbContext.Orders.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(Order entity)
    {
        _dbContext.Orders.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<Order>> GetAllAsync()
    {
        return await _dbContext.Orders
            .Include(o => o.Table)
            .Include(o => o.OrderDetails)
            .Include("OrderDetails.Product")
            .ToArrayAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _dbContext.Orders
            .Include(o => o.Table)
            .Include(o => o.OrderDetails)
            .Include("OrderDetails.Product")
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task DeleteAsync(int id)
    {
        Order entity = await _dbContext.Orders.SingleAsync(p => p.Id == id);
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}