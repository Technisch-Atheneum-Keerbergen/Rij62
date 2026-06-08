using Rij62.Models.Api;

namespace Rij62.Models;

public class MenuPreset
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public WeekDayRepeat Repeat { get; set; }
    public bool Enabled { get; set; }

    public ICollection<MenuPresetLink> Links { get; set; }
    public ICollection<Product> Products { get; set; }

    public static MenuPreset FromApiMenuPreset(ApiCreateMenuPresetRequest preset)
    {
        return new MenuPreset
        {
            Id = 0,
            Name = preset.Name,
            Repeat = preset.Repeat,
            Enabled = preset.Enabled,
        };
    }
}


