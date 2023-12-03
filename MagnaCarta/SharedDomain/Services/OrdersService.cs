using SharedDomain.Entities;
using SharedDomain.Repositories;

namespace SharedDomain.Services;

internal class OrdersService : IOrdersService
{
    private readonly IRepository<Order> _repository;

    public OrdersService(IRepository<Order> repository)
    {
        _repository = repository;
    }

    public async Task<Order?> GetOrder(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IReadOnlyCollection<Order>> GetAllOrders()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Order> AddOrder(Order order)
    {
        return await _repository.CreateAsync(order);
    }

    public async Task UpdateOrder(Order order)
    {
        await _repository.UpdateAsync(order);
    }

    public async Task DeleteOrder(int id)
    {
        await _repository.DeleteAsync(id);
    }
}