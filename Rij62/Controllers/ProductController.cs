using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IEnumerable<ApiGetProduct>> GetProducts()
        {
            var languages = await _context.Language.ToArrayAsync();

            return _context.Products.Select(p => new ApiGetProduct
            {
                Title = MultiLangString.FromLangEntryKey(languages, p.TitleKey),
                Description = MultiLangString.FromLangEntryKey(languages, p.DescriptionKey),
                Id = p.Id,
                Price = p.PriceCent,
                Stock = p.Stock,
                IsAvailible = p.IsAvailable,
                ImgURL = p.ImgUrl,
                CategoryId = p.CategoryId,
            });
        }

        public async Task<IActionResult> PostProduct(ApiPutProduct apiProduct)
        {
            var uniqueId = Guid.NewGuid().ToString();
            var descriptionKey = "ProductDescription-"+uniqueId;
            var titleKey = "ProductTitle-"+uniqueId;
            var createdProduct = new Product
            {
                Id = 0,
                TitleKey=titleKey,
                DescriptionKey=descriptionKey,
                PriceCent = apiProduct.Price,
                Stock = apiProduct.Stock,
                IsAvailable = apiProduct.IsAvailible,
                ImgUrl = apiProduct.ImgURL,
                CategoryId = apiProduct.CategoryId,
            };
            _context.Products.Add(createdProduct);

            _context.UpdateLanguageEntry(apiProduct.Title, titleKey);
            _context.UpdateLanguageEntry(apiProduct.Description, descriptionKey);

            await _context.SaveChangesAsync();
            return Created();
        }
        

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ApiPutProduct apiProduct)
        {

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
               return NotFound();
            }

            _context.UpdateLanguageEntry(apiProduct.Title, product.TitleKey);
            _context.UpdateLanguageEntry(apiProduct.Description, product.DescriptionKey);

            product.PriceCent = apiProduct.Price;
            product.Stock = apiProduct.Stock;
            product.IsAvailable = apiProduct.IsAvailible;
            product.CategoryId = apiProduct.CategoryId;
            product.ImgUrl = apiProduct.ImgURL;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}