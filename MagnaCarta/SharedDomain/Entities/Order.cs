using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDomain.Entities;

public class Order
{
    public Order()
    {
    }
    
    public Order(Table table)
    {
        Date = DateTime.Now;
        Status = OrderStatus.Created;
        Table = table;
        TableId = table.Id;
    }
    
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public OrderStatus Status { get; set; }
    
    public int TableId { get; set; }
    public virtual Table Table { get; set; }

    public virtual List<OrderDetail> OrderDetails { get; set; } = new();
    [NotMapped] public decimal Total => OrderDetails.Sum(od => od.Total);
    [NotMapped] public IReadOnlyCollection<OrderDetail> ConfirmedDetails => OrderDetails.Where(od => od.Status == OrderDetailStatus.Confirmed).ToList();
    [NotMapped] public IReadOnlyCollection<OrderDetail> ReadyDetails => OrderDetails.Where(od => od.Status == OrderDetailStatus.Ready).ToList();

    public void ConfirmOrder()
    {
        if (Status != OrderStatus.Created)
        {
            throw new InvalidOperationException();
        }
        Status = OrderStatus.Confirmed;
        Date = DateTime.Now;
        OrderDetails.ForEach(d => d.ConfirmDetail());
    }
    
    public void CloseOrder()
    {
        if (Status != OrderStatus.Confirmed)
        {
            throw new InvalidOperationException();
        }
        Status = OrderStatus.Closed;
    }

    public void AddProduct(Product product)
    {
        CheckOrderIsEditable("No se puede editar un pedido cerrado");
        var detail = GetOrderDetailByProduct(product);
        if (detail == null)
        {
            detail = new OrderDetail(this, product);
            OrderDetails.Add(detail);
        }
        else
        {
            detail.IncrementQuantity();
        }
    }
    
    public void RemoveProduct(Product product)
    {
        CheckOrderIsEditable("No se puede editar un pedido cerrado");
        var detail = GetOrderDetailByProduct(product);
        if (detail == null)
        {
            throw new InvalidOperationException($"No existe detalle para el producto ${product.Name}");
        }
        detail.DecrementQuantity();
        if (detail.Quantity <= 0)
        {
            OrderDetails.Remove(detail);
        }
    }

    private OrderDetail? GetOrderDetailByProduct(Product product)
    {
        return OrderDetails.FirstOrDefault(d => d.ProductId == product.Id);
    }

    public bool IsActive()
    {
        return Status != OrderStatus.Closed;
    }

    public bool IsEditable()
    {
        return Status == OrderStatus.Created;
    }

    private void CheckOrderIsEditable(string msg)
    {
        if (!IsEditable())
        {
            throw new InvalidOperationException(msg);
        }
    }
}

public enum OrderStatus
{
    Created,
    Confirmed,
    Closed
}