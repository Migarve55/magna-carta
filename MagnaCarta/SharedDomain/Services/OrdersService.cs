using System.Linq;
using Microsoft.AspNetCore.SignalR;
using SharedDomain.Entities;
using SharedDomain.Hubs;
using SharedDomain.Repositories;

namespace SharedDomain.Services;

internal class OrdersService : IOrdersService
{
    private readonly IRepository<Order> _repository;
    private IHubContext<OrdersHub> _context;

    public OrdersService(IRepository<Order> repository, IHubContext<OrdersHub> context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<Order?> GetOrder(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Order> GetOrCreateOrderForTable(Table table)
    {
        var orders = await _repository.GetAllAsync();
        var order = orders.FirstOrDefault(o => o.TableId == table.Id && o.IsActive());
        if (order == null)
        {
            order = new Order(table);
            await _repository.CreateAsync(order);
        }

        return order;
    }

    public async Task<PaginatedResult<Order>> GetOrdersOrderedByDate(PaginationRequest paginationRequest, DateTime startDate, DateTime endDate)
    {
        var orders = await _repository.GetAllAsync();
        var result = orders
            .Where(o => o.Date >= startDate && o.Date <= endDate)
            .OrderByDescending(o => o.Date)
            .ThenBy(o => o.Status)
            .ToList();

        return PaginatedResult<Order>.ToPaginatedResult(result, paginationRequest.Page, paginationRequest.PerPage);
    }

    public async Task<IReadOnlyCollection<Order>> GetOrdersWithConfirmedDetails()
    {
        var orders = await _repository.GetAllAsync();
        return orders
            .Where(o => o.ConfirmedDetails.Any())
            .ToList();
    }

    public async Task<Order> AddProductToTableOrder(Table table, Product product)
    {
        var order = await GetOrCreateOrderForTable(table);
        order.AddProduct(product);
        await _repository.UpdateAsync(order);
        return order;
    }
    
    public async Task<Order> RemoveProductFromTableOrder(Table table, Product product)
    {
        var order = await GetOrCreateOrderForTable(table);
        order.RemoveProduct(product);
        await _repository.UpdateAsync(order);
        return order;
    }

    public async Task ConfirmOrder(Order order)
    {
        order.ConfirmOrder();
        await _repository.UpdateAsync(order);
    }

    public async Task CloseOrder(Order order)
    {
        order.CloseOrder();
        await _repository.UpdateAsync(order);
    }

    public async Task MarkAsReady(OrderDetail detail)
    {
        detail.MarkDetailAsReady();
        await _repository.UpdateAsync(detail.Order);
        await NotifyOrderDetailUpdatedAsync(detail);
    }

    public async Task MarkAsDelivered(OrderDetail detail)
    {
        detail.MarkDetailAsDelivered();
        await _repository.UpdateAsync(detail.Order);
        await NotifyOrderDetailUpdatedAsync(detail);
    }

    private async Task NotifyOrderDetailUpdatedAsync(OrderDetail orderDetail)
    {
        await _context.Clients.All.SendAsync("OrderDetailUpdated", orderDetail.OrderId, orderDetail.Id, orderDetail.Status);
    }
}