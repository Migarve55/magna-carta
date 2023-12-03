using System.ComponentModel.DataAnnotations;

namespace SharedDomain.Entities;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public OrderStatus Status { get; set; }
    
    public int TableId { get; set; }
    public virtual Table Table { get; set; }
}

public enum OrderStatus
{
    Created,
    Closed
}