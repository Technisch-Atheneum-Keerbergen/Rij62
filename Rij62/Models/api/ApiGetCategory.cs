using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetCategory
{
    public int Id { get; set; }
    public required MultiLangString Name { get; set; }
    public int? ScreenId { get; set; }

    public static ApiGetCategory FromCategory(ProductCategory cat, LangEntry[] entries)
    {
        return new ApiGetCategory
        {
            Id = cat.Id,
            Name = MultiLangString.FromLangEntryKey(entries, cat.NameKey),
            ScreenId = cat.ScreenId,
        };
    }
}


