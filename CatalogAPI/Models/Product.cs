using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogAPI.Models;

//[Table("Products")]
public class Product
{
    //[Key]
    public int Id { get; set; }

    [Required]
    [StringLength(90)]
    public string? Name { get; set; }

    [Required]
    [StringLength(400)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public float Inventory { get; set; }
    public DateTime RegistrationDate { get; set; }
}
