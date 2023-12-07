using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDomain.Entities;

public class OrderDetail
{
    public OrderDetail()
    {
    }
    
    public OrderDetail(Order order, Product product)
    {
        Order = order;
        OrderId = order.Id;
        Product = product;
        ProductId = product.Id;
        Quantity = 1;
        Status = OrderDetailStatus.Created;
    }

    [Key]
    public int Id { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public OrderDetailStatus Status { get; set; }
    
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }

    [NotMapped] public decimal Total => Product.Price * Quantity;

    public void IncrementQuantity()
    {
        if (Status != OrderDetailStatus.Created)
        {
            throw new InvalidOperationException();
        }
        Quantity++;
    }

    public void DecrementQuantity()
    {
        if (Status != OrderDetailStatus.Created)
        {
            throw new InvalidOperationException();
        }
        Quantity--;
    }

    public void ConfirmDetail()
    {
        if (Status != OrderDetailStatus.Created)
        {
            throw new InvalidOperationException();
        }
        Status = OrderDetailStatus.Confirmed;
    }
    
    public void MarkDetailAsReady()
    {
        if (Status != OrderDetailStatus.Confirmed)
        {
            throw new InvalidOperationException();
        }
        Status = OrderDetailStatus.Ready;
    }
    
    public void MarkDetailAsDelivered()
    {
        if (Status != OrderDetailStatus.Ready)
        {
            throw new InvalidOperationException();
        }
        Status = OrderDetailStatus.Delivered;
    }
}

public enum OrderDetailStatus
{
    Created,
    Confirmed,
    Ready,
    Delivered
}
