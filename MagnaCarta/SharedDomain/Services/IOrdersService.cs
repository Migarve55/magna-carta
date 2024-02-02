using SharedDomain.Entities;

namespace SharedDomain.Services;

public interface IOrdersService
{
    Task<Order?> GetOrder(int id);
    Task<Order> GetOrCreateOrderForTable(Table table);
    Task<PaginatedResult<Order>> GetOrdersOrderedByDate(PaginationRequest paginationRequest, DateTime startDate, DateTime endDate);
    Task<IReadOnlyCollection<Order>> GetActiveOrdersForTodayWithConfirmedDetails();
    Task<Order> AddProductToTableOrder(Table table, Product product);
    Task<Order> RemoveProductFromTableOrder(Table table, Product product);
    Task ConfirmPendingDetails(Order order);
    Task CloseOrder(Order order);
    Task MarkAsReady(OrderDetail detail);
    Task MarkAsDelivered(OrderDetail detail);
}