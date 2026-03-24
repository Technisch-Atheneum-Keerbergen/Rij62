using System.Diagnostics;
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

            return _context.Products.Include((p) => p.Steps).Select((p) => ApiGetProduct.FromProduct(p, localizer));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var localizer = await _localization.GetLocalizer();

            var product = await _context.Products.Include((p) => p.Steps).Where((p) => p.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(ApiGetProduct.FromProduct(product, localizer));
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("")]
        public async Task<IActionResult> PostProduct([FromBody] ApiPutProduct apiProduct)
        {
            var createdProduct = Product.FromApiPutProduct(apiProduct);
            _context.Products.Add(createdProduct);

            _localization.UpdateLanguageEntry(apiProduct.Title, createdProduct.TitleKey);
            _localization.UpdateLanguageEntry(apiProduct.Description, createdProduct.DescriptionKey);

            await _context.SaveChangesAsync();

            return Ok(createdProduct.Id);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("{productId}/step")]
        public async Task<IActionResult> PostStep(int productId, [FromBody] ApiPutStep apiStep)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var stepTitleKey = Localizer.UniqueKey("ProductStep");
            var createdProductStep = new ProductStep
            {
                Id = 0,
                ProductId = productId,
                DefaultOptionId = apiStep.DefaultOptionId,
                MultipleChoice = apiStep.MultipleChoice,
                TitleKey = stepTitleKey
            };
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                _context.ProductSteps.Add(createdProductStep);
                _localization.UpdateLanguageEntry(apiStep.Title, stepTitleKey);

                await _context.SaveChangesAsync();

                foreach (var option in apiStep.Options)
                {
                    _context.ProductStepOptions.Add(new ProductStepOption
                    {
                        ProductStepId = createdProductStep.Id,
                        ProductId = option,
                    });
                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return Ok(createdProductStep.Id);
            }

        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{productId}/step/{stepId}")]
        public async Task<IActionResult> DeleteStep(int productId, int stepId)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var step = await _context.ProductSteps.Where((s) => s.ProductId == productId && s.Id == stepId).Include((s) => s.Options).FirstOrDefaultAsync();
                if (step == null)
                {
                    return NotFound();
                }
                await _context.ProductStepOptions.Where((s) => s.ProductStepId == step.Id).ExecuteDeleteAsync();
                await _context.ProductSteps.Where((s) => s.Id == stepId).ExecuteDeleteAsync();
                await transaction.CommitAsync();
            }

            return Ok();
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

            await _context.ProductSteps.Select((p) => p.ProductId == product.Id).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}