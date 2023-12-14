using System.ComponentModel.DataAnnotations;

namespace SharedDomain.Entities;

public class Table
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MaxLength(500, ErrorMessage = "La longuitud máxima es 500 caracteres")]
    public string Name { get; set; }

    public virtual List<Order> Orders { get; set; } = new();
}