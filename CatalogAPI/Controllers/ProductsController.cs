﻿using CatalogAPI.Context;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CatalogAPIContext _context;

        public ProductsController(CatalogAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var products = _context.Products.ToList();
            return (products == null) ? NotFound() : Ok(products);
        }

        [HttpGet("{id:int}",Name ="GetProduct")]
        public ActionResult Get(int id)
        {
            var products = _context.Products.FirstOrDefault(p => p.Id == id);
            return (products == null) ? NotFound() : Ok(products);
        }

        [HttpPost]
        public ActionResult Post(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
        }
    }
}
