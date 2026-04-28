using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;
using Rij62.Services;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly LocalizationService _localization;

        public CategoryController(AppDbContext context, LocalizationService localization)
        {
            _context = context;
            _localization = localization;
        }


        [HttpGet("")]
        public async Task<IEnumerable<ApiGetCategory>> GetCategories()
        {
            var localizationEntries = await _localization.GetLocalizer();
            return _context.ProductCategories.Select((c) => ApiGetCategory.FromCategory(c, localizationEntries));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var cat = await _context.ProductCategories.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return Ok(ApiGetCategory.FromCategory(cat, await _localization.GetLocalizer()));
        }
        [Authorize(Policy = "AdminOnly")]
        [HttpPost("")]
        public async Task<IActionResult> PostCategory([FromBody] ApiPutCategory apiCat)
        {
            var uniqueId = Guid.NewGuid().ToString();
            var nameKey = "ProductCategoryName-" + uniqueId;
            _localization.UpdateLanguageEntry(apiCat.Name, nameKey);
            var cat = new ProductCategory
            {
                NameKey = nameKey,
                ImgUrl = apiCat.ImgUrl,
                RootCategory = apiCat.RootCategory,
            };
            _context.ProductCategories.Add(cat);

            await _context.SaveChangesAsync();
            return Ok(cat.Id);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] ApiPutCategory apiCat)
        {
            var cat = await _context.ProductCategories.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }

            _localization.UpdateLanguageEntry(apiCat.Name, cat.NameKey);

            cat.RootCategory = apiCat.RootCategory;
            cat.ImgUrl = apiCat.ImgUrl;

            _context.Entry(cat).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /* moveProducts: Category id of the category to move all the products of the deleted category to*/
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id, [FromQuery] int moveProducts)
        {
            using (var trans = await _context.Database.BeginTransactionAsync())
            {

                var destCat = await _context.ProductCategories.FindAsync(moveProducts);
                if (destCat == null)
                {
                    return NotFound("Destination category not found");
                }

                var cat = await _context.ProductCategories.FindAsync(id);
                if (cat == null)
                {
                    return NotFound();
                }
                // Move all products
                await _context.Products.Where((p) => p.CategoryId == cat.Id).ExecuteUpdateAsync((p) => p.SetProperty((p) => p.CategoryId, destCat.Id));

                await _localization.DeleteLanguageEntry(cat.NameKey);
                _context.ProductCategories.Remove(cat);

                await _context.SaveChangesAsync();
                await trans.CommitAsync();
                return Ok();
            }
        }
    }
}
