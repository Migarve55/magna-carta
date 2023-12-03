using System.ComponentModel.DataAnnotations;

namespace SharedDomain.Entities;

public class Table
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }
    
    public virtual List<Order> Orders { get; set; }
}