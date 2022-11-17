﻿using CatalogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Context;

public class CatalogAPIContext : DbContext
{
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Product>? Products { get; set; }

    public CatalogAPIContext(DbContextOptions<CatalogAPIContext> options) : base(options)
    {
    }
}
