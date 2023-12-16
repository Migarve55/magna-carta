using SharedDomain.Entities;

namespace SharedDomain.Services;

public interface IOrdersService
{
    Task<Order?> GetOrder(int id);
    Task<Order> GetOrCreateOrderForTable(Table table);
    Task<IReadOnlyCollection<Order>> GetOrdersOrderedByDate(DateTime startDate, DateTime endDate);
    Task<IReadOnlyCollection<Order>> GetOrdersWithConfirmedDetails();
    Task<IReadOnlyCollection<Order>> GetOrdersWithReadyDetails();
    Task<Order> AddProductToTableOrder(Table table, Product product);
    Task<Order> RemoveProductFromTableOrder(Table table, Product product);
    Task ConfirmOrder(Order order);
    Task CloseOrder(Order order);
    Task MarkAsReady(OrderDetail detail);
    Task MarkAsDelivered(OrderDetail detail);
}