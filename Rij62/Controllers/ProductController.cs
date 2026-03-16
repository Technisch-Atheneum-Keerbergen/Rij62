using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;
using Rij62.Services;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly LocalizationService _localization;

        public ProductController(AppDbContext context, LocalizationService localization)
        {
            _context = context;
            _localization = localization;
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
                Btw = p.Btw,
                Stock = p.Stock,
                IsAvailable = p.IsAvailable,
                ImgURL = p.ImgUrl,
                CategoryId = p.CategoryId,
            });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var languages = await _context.Language.ToArrayAsync();

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(new ApiGetProduct
            {
                Title = MultiLangString.FromLangEntryKey(languages, product.TitleKey),
                Description = MultiLangString.FromLangEntryKey(languages, product.DescriptionKey),
                Id = product.Id,
                Price = product.PriceCent,
                Btw = product.Btw,
                Stock = product.Stock,
                IsAvailable = product.IsAvailable,
                ImgURL = product.ImgUrl,
                CategoryId = product.CategoryId,
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
                Btw = apiProduct.Btw,
                Stock = apiProduct.Stock,
                IsAvailable = apiProduct.IsAvailable,
                ImgUrl = apiProduct.ImgURL,
                CategoryId = apiProduct.CategoryId,
            };
            _context.Products.Add(createdProduct);

            _localization.UpdateLanguageEntry(apiProduct.Title, titleKey);
            _localization.UpdateLanguageEntry(apiProduct.Description, descriptionKey);

            await _context.SaveChangesAsync();
            return Ok(createdProduct.Id);
        }
        

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ApiPutProduct apiProduct)
        {

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
               return NotFound();
            }

            _localization.UpdateLanguageEntry(apiProduct.Title, product.TitleKey);
            _localization.UpdateLanguageEntry(apiProduct.Description, product.DescriptionKey);

            product.PriceCent = apiProduct.Price;
            product.Btw = apiProduct.Btw;
            product.Stock = apiProduct.Stock;
            product.IsAvailable = apiProduct.IsAvailable;
            product.CategoryId = apiProduct.CategoryId;
            product.ImgUrl = apiProduct.ImgURL;

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await _localization.DeleteLanguageEntry(product.TitleKey);
            await _localization.DeleteLanguageEntry(product.DescriptionKey);
            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}