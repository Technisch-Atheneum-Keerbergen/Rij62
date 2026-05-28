
using Rij62.Models;

namespace Rij62;

public class MenuPresets
{
    MenuPresetLink[] _links;

    public MenuPresets(MenuPresetLink[] links)
    {
        _links = links;
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
        var found = false;
        foreach (var link in _links)
        {
            if (link.ProductId == product.Id)
            {
                found = true;
                if (IsPresetActive(link.MenuPreset, date))
                {
                    return true;
                }
            }
        }
        return !found; // if we found nothing the product should be enabled.

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
