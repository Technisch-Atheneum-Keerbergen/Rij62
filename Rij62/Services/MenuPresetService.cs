using Rij62.Data;
using Rij62.Models;

namespace Rij62.Services;

public class MenuPresetService
{
    private readonly AppDbContext _context;

    private MenuPreset[] _presets;
    public MenuPresetService(AppDbContext context)
    {
        _context = context;
    }


    public MenuPreset[] GetPresets()
    {
        if (_presets == null)
        {
            _presets = _context.MenuPresets.ToArray();
        }

        return _presets;
    }

    public bool IsPresetActive(MenuPreset preset, DateTime? date=null)
    {
        if (!preset.Enabled)
        {
            return false;
        }

        if (date == null)
        {
            date = DateTime.UtcNow;
        }
        
        switch(date.Value.DayOfWeek)
        {
            case DayOfWeek.Monday:
                Weekday.Monday;
                break;
        }
        if (preset.Repeat.HasFlag(Weekday.Monday))
                {
                    
                }

    }

    public bool IsProductActive(Product product, DateTime? date=null)
    {


        var InPreset = false;
        foreach (var preset in GetPresets())
        {
            if (product.MenuPresetId == preset.Id)
            {
                InPreset = true;
                if (IsPresetActive(date))
                {
                    return true;
                }
            }
           
        }
        // Products that are not in a preset will always be enabled.
        return !InPreset;
    }
}