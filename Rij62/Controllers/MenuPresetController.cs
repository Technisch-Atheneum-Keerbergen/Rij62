using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Services;
using Rij62.Models;
using Rij62.Models.Api;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MenuPresetController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly MenuPresetService _menuPresetService;
        private readonly LocalizationService _localizationService;
        private readonly UrlService _urlService;

        public MenuPresetController(AppDbContext context, MenuPresetService menuPresetService, LocalizationService localizationService, UrlService urlService)
        {
            _context = context;
            _menuPresetService = menuPresetService;
            _localizationService = localizationService;
            _urlService = urlService;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("")]
        public async Task<IActionResult> GetMenuPresets()
        {
            var localizer = await _localizationService.GetLocalizer();
            var presets = await _menuPresetService.GetPresets();
            return Ok(await _context.MenuPresets.Include((m) => m.Links).ThenInclude((l) => l.Product).Select((p) => ApiGetMenuPresetResponse.FromMenuPreset(p, presets, localizer, _urlService)).ToArrayAsync());
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("")]
        public async Task<IActionResult> PostMenuPreset([FromBody] ApiCreateMenuPresetRequest api)
        {
            var menuPreset = MenuPreset.FromApiMenuPreset(api);
            _context.MenuPresets.Add(menuPreset);
            await _context.SaveChangesAsync();

            var result = await _menuPresetService.AddProductsToPreset(menuPreset, api.Products);
            if (result != null)
            {
                return BadRequest($"Product with id {result.Value.ProductId} doesn't exist");
            }

            return Ok();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuPreset(int id, [FromBody] ApiCreateMenuPresetRequest api)
        {
            var preset = await _context.MenuPresets.FindAsync(id);
            if (preset == null)
            {
                return NotFound();
            }

            preset.Name = api.Name;
            preset.Repeat = api.Repeat;
            preset.Enabled = api.Enabled;
            _context.Entry(preset).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await _context.MenuPresetLinks.Where((l) => l.MenuPresetId == preset.Id).ExecuteDeleteAsync();
            var result = await _menuPresetService.AddProductsToPreset(preset, api.Products);
            if (result != null)
            {
                return BadRequest($"Product with id {result.Value.ProductId} doesn't exist");
            }

            return Ok();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuPreset(int id)
        {
            var preset = await _context.MenuPresets.FindAsync(id);
            if (preset == null)
            {
                return NotFound();
            }
            _context.MenuPresets.Remove(preset);
            await _context.SaveChangesAsync();
            await _context.MenuPresetLinks.Where((l) => l.MenuPresetId == preset.Id).ExecuteDeleteAsync();

            return Ok();
        }

    }
}
