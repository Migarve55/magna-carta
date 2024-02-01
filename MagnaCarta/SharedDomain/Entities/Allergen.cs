using System.ComponentModel.DataAnnotations;

namespace SharedDomain.Entities;

public class Allergen
{
    public Allergen()
    {
    }
    
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Symbol { get; set; }
    
    public virtual List<Product> Products { get; set; } = new();
}