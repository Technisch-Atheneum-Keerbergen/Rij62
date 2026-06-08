namespace Rij62.Models.Api;

using Rij62.Services;

public class ApiGetMenuPresetResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required WeekDayRepeat Repeat { get; set; }
    public required bool Enabled { get; set; }
    public required ApiGetProductResponse[] Products { get; set; }

    public static ApiGetMenuPresetResponse FromMenuPreset(MenuPreset preset, MenuPresets presets, Localizer localizer, UrlService urlService)
    {
        if (preset.Links == null)
        {
            throw new ArgumentNullException("MenuPreset.Products is null make sure you load it from the database");
        }

        return new ApiGetMenuPresetResponse
        {
            Id = preset.Id,
            Name = preset.Name,
            Repeat = preset.Repeat,
            Enabled = preset.Enabled,
            Products = preset.Links.Select((p) => ApiGetProductResponse.FromProduct(p.Product, presets, localizer, urlService, includeSteps: false)).ToArray()
        };

    }
}
