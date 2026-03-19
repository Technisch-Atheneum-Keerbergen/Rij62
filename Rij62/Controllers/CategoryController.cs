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

        [HttpPost("")]
        public async Task<IActionResult> PostCategory([FromBody] ApiPutCategory apiCat)
        {
            var uniqueId = Guid.NewGuid().ToString();
            var nameKey = "ProductCategoryName-"+uniqueId;
            _localization.UpdateLanguageEntry(apiCat.Name, nameKey);
            var cat = new ProductCategory
            {
                NameKey=nameKey, 
                ScreenId=apiCat.ScreenId,
            };
            _context.ProductCategories.Add(cat);

            await _context.SaveChangesAsync();
            return Ok(cat.Id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, [FromBody] ApiPutCategory apiCat)
        {
             var cat = await _context.ProductCategories.FindAsync(id);
            if (cat == null)
            {
               return NotFound();
            }

            _localization.UpdateLanguageEntry(apiCat.Name, cat.NameKey);

            cat.ScreenId = apiCat.ScreenId;

            _context.Entry(cat).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        } 

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            var cat = await _context.ProductCategories.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            await _localization.DeleteLanguageEntry(cat.NameKey);
            _context.ProductCategories.Remove(cat);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}