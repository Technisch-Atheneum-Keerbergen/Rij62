using Rij62.Data;
using Rij62.Models;

namespace Rij62.Services;

public class MenuPresetService
{
    private readonly AppDbContext _context;

    private MenuPreset[]? _presets;

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

    public bool IsPresetActive(MenuPreset preset, DateTime? date = null)
    {
        if (!preset.Enabled)
        {
            return false;
        }

        if (date == null)
        {
            date = DateTime.UtcNow;
        }

        var weekDayRepeat = WeekDayRepeatHelper.FromDayOfWeek(date.Value.DayOfWeek);
        return preset.Repeat.HasFlag(weekDayRepeat);
    }

    public bool IsProductActive(Product product, DateTime? date = null)
    {
        // Products that are not in a preset will always be enabled.
        if (product.MenuPresetId == null)
        {
            return true;
        }


        foreach (var preset in GetPresets())
        {
            if (product.MenuPresetId == preset.Id && IsPresetActive(preset, date))
            {
                return true;
            }
        }
        return false;
    }
}
