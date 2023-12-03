using System.ComponentModel.DataAnnotations;

namespace SharedDomain.Entities;

public class OrderDetail
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public OrderDetailStatus Status { get; set; }
    
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
}

public enum OrderDetailStatus
{
    Ordered,
    Ready,
    Delivered
}
