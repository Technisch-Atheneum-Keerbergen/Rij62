using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Authorization;
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
            var localizer = await _localization.GetLocalizer();

            return _context.Products.Include((p) => p.Steps).Select((p)=> ApiGetProduct.FromProduct(p, localizer));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var localizer = await _localization.GetLocalizer();

            var product = await _context.Products.Include((p)=> p.Steps).Where((p)=>p.Id==id).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(ApiGetProduct.FromProduct(product, localizer));
        }

        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> PostProduct(ApiPutProduct apiProduct)
        {
            var descriptionKey = _localization.UniqueKey("ProductDescription");
            var titleKey = _localization.UniqueKey("ProductTitle");
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

            foreach (var step in apiProduct.Steps)
            {
                var stepTitleKey = _localization.UniqueKey("ProductStep");
                var createdProductStep = new ProductStep
                {
                    Id= 0,
                    ProductId = createdProduct.Id,
                    DefaultOptionId = step.DefaultOptionId,
                    MultipleChoice = step.MultipleChoice,
                    TitleKey = stepTitleKey
                };
                _context.ProductSteps.Add(createdProductStep);
                _localization.UpdateLanguageEntry(step.Title, stepTitleKey);

                await _context.SaveChangesAsync();

                foreach (var option in step.Options)
                {
                    _context.ProductStepOptions.Add(new ProductStepOption
                    {
                        ProductStepId = createdProductStep.Id,
                        ProductId = option,
                    });
                }
            }
           

            await _context.SaveChangesAsync();
            return Ok(createdProduct.Id);
        }
        
        [Authorize(Policy = "AdminOnly")]
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

        [Authorize(Policy = "AdminOnly")]
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