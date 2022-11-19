using CatalogAPI.Context;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CatalogAPIContext _context;

        public CategoriesController(CatalogAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var categories = _context.Categories.AsNoTracking().ToList();

            return (categories == null) ? NotFound() : Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public ActionResult Get(int id)
        {
            var category = _context.Categories.Find(id);

            return (category == null) ? NotFound() : Ok(category);
        }

        [HttpGet("products")]
        public ActionResult GetCategoriesWithProducts()
        {
            return Ok(_context.Categories.Include(p => p.Products).AsNoTracking().ToList());
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (category == null) return BadRequest();

            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category)
        {
            if (category.Id != id) return BadRequest();

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok();
        }
    }
}
