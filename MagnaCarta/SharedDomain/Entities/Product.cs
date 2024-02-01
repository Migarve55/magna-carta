using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedDomain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MaxLength(500, ErrorMessage = "La longuitud máxima es 500 caracteres")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "La descripción es obligatoria")]
    [MaxLength(2000, ErrorMessage = "La longuitud máxima es 2000 caracteres")]
    public string Description { get; set; }
    
    [Required]
    public ProductType Type { get; set; }
    
    [Required]
    [Range(0, Double.PositiveInfinity, ErrorMessage = "El precio tiene que ser positivo")]
    public decimal Price { get; set; }

    public virtual List<Allergen> Allergens { get; set; } = new();

    [NotMapped] public bool IsVegetarian => Type == ProductType.Vegetarian;
    [NotMapped] public bool IsVegan => Type == ProductType.Vegan;
}

public enum ProductType
{
    Normal,
    Vegetarian,
    Vegan
}