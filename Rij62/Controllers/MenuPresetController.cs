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
        public async Task<IActionResult> PostMenuPreset(ApiPutMenuPreset api)
        {
            _context.MenuPresets.Add(MenuPreset.FromApiMenuPreset(api));
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
