using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // Get all products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        // Get product by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        // Create a new product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Update a product
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            if (id != updatedProduct.Id) return BadRequest();

            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            product.TitleKey = updatedProduct.TitleKey;
            product.DescriptionKey = updatedProduct.DescriptionKey;
            product.PriceCent = updatedProduct.PriceCent;
            product.Stock = updatedProduct.Stock;
            product.IsAvailable = updatedProduct.IsAvailable;
            product.ImgUrl = updatedProduct.ImgUrl;
            product.CategoryId = updatedProduct.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        // GET: api/product/sampleData
        [HttpPost("sampleData")]
        public IActionResult CreateSampleData()
        {
            var sample = new[] {
                new Product { TitleKey = "Sample1", DescriptionKey = "Desc1", PriceCent = 1000, Stock = 10, IsAvailable = true, ImgUrl = "sample1.jpg", CategoryId = 1 },
                new Product { TitleKey = "Sample2", DescriptionKey = "Desc2", PriceCent = 2000, Stock = 5, IsAvailable = true, ImgUrl = "sample2.jpg", CategoryId = 2 }
            };
            foreach (var product in sample)
            {
                if (!_context.Products.Any(p => p.TitleKey == product.TitleKey && p.DescriptionKey == product.DescriptionKey))
                {
                    _context.Products.Add(product);
                }
            }
            _context.SaveChanges();
            return Ok(sample);
        }
    }
}