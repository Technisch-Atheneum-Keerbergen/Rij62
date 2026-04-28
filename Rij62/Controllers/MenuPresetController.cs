using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;
using Rij62.Models.Api;

namespace Rij62.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MenuPresetController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MenuPresetController(AppDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("")]
        public async Task<IActionResult> GetMenuPresets()
        {
            return Ok(_context.MenuPresets.ToAsyncEnumerable());
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost("")]
        public async Task<IActionResult> PostMenuPreset([FromBody] ApiPutMenuPreset api)
        {
            _context.MenuPresets.Add(MenuPreset.FromApiMenuPreset(api));
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenuPreset(int id, [FromBody] ApiPutMenuPreset api)
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
            return Ok();
        }

    }
}
