using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Services;

public struct ProductIdDoesntExistError
{
    public required int ProductId { get; set; }
}

public class MenuPresetService
{
    private readonly AppDbContext _context;

    private MenuPresets? _presets;

    public MenuPresetService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ProductIdDoesntExistError?> AddProductsToPreset(MenuPreset preset, IEnumerable<int> productIds)
    {
        foreach (var productId in productIds)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return new ProductIdDoesntExistError { ProductId = productId };
            }
            _context.MenuPresetLinks.Add(new MenuPresetLink { ProductId = productId, MenuPresetId = preset.Id });
        }
        await _context.SaveChangesAsync();
        return null;
    }


    public async Task<MenuPresets> GetPresets()
    {
        if (_presets == null)
        {
            _presets = new MenuPresets(await _context.MenuPresetLinks.Include((l) => l.MenuPreset).ToArrayAsync());
        }

        return _presets;
    }

}
