﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogAPI.Models;

//[Table("Categories")]
public class Category
{
    //[Key]
    public int Id { get; set; }

    [Required]
    [StringLength(60)]
    public string? Name { get; set; }

    [Required]
    [StringLength(300)]
    public string? ImageUrl { get; set; }

    public ICollection<Product>? Products { get; set; } = new Collection<Product>();
}
