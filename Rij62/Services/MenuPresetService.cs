using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Services;

public class MenuPresetService
{
    private readonly AppDbContext _context;

    private MenuPresets? _presets;

    public MenuPresetService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<MenuPresets> GetPresets()
    {
        if (_presets == null)
        {
            _presets = new MenuPresets(await _context.MenuPresets.ToArrayAsync());
        }

        return _presets;
    }

   
}
