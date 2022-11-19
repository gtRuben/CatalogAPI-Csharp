using CatalogAPI.Context;
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

        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            var products = _context.Products.FirstOrDefault(p => p.Id == id);
            return (products == null) ? NotFound() : Ok(products);
        }
    }
}
