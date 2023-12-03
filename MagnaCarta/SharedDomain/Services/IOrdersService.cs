using SharedDomain.Entities;

namespace SharedDomain.Services;

public interface IOrdersService
{
    Task<Order?> GetOrder(int id);
    Task<IReadOnlyCollection<Order>> GetAllOrders();
    Task<Order> AddOrder(Order order);
    Task UpdateOrder(Order order);
    Task DeleteOrder(int id);
}