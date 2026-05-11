
using Rij62.Models;

namespace Rij62;

public class MenuPresets
{
    MenuPreset[] _presets;

    public MenuPresets(MenuPreset[] presets)
    {
        _presets = presets;
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


        foreach (var preset in _presets)
        {
            if (product.MenuPresetId == preset.Id && IsPresetActive(preset, date))
            {
                return true;
            }
        }
        return false;
    }

    public bool IsProductActiveAndAvailable(Product product, DateTime? date = null)
    {
        if (!product.IsAvailable)
        {
            return false;
        }
        return IsProductActive(product, date);
    }
}