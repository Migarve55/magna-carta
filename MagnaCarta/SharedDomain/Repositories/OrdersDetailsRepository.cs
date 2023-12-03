using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedDomain.Data;
using SharedDomain.Entities;

namespace SharedDomain.Repositories;

public class OrdersDetailsRepository : IRepository<OrderDetail>
{
    private readonly ApplicationDbContext _dbContext;

    public OrdersDetailsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<OrderDetail> CreateAsync(OrderDetail entity)
    {
        EntityEntry<OrderDetail> entityEntry = await _dbContext.OrderDetails.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async Task UpdateAsync(OrderDetail entity)
    {
        _dbContext.OrderDetails.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyCollection<OrderDetail>> GetAllAsync()
    {
        return await _dbContext.OrderDetails.ToArrayAsync();
    }

    public async Task<OrderDetail?> GetByIdAsync(int id)
    {
        return await _dbContext.OrderDetails.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task DeleteAsync(int id)
    {
        OrderDetail entity = await _dbContext.OrderDetails.SingleAsync(p => p.Id == id);
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }
}