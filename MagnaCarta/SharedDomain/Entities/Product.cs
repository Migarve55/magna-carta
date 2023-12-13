using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDomain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(500)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(2000)]
    public string Description { get; set; }
    
    [Required]
    public ProductType Type { get; set; }
    
    [Required]
    [Range(0, Double.PositiveInfinity)]
    public decimal Price { get; set; }

    [NotMapped] public bool IsVegetarian => Type == ProductType.Vegetarian;
    [NotMapped] public bool IsVegan => Type == ProductType.Vegan;
}

public enum ProductType
{
    Normal,
    Vegetarian,
    Vegan
}