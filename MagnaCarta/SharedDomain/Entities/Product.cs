using System.ComponentModel.DataAnnotations;

namespace SharedDomain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }
    
    [Required]
    [Range(0, Double.PositiveInfinity)]
    public decimal Price { get; set; }
}