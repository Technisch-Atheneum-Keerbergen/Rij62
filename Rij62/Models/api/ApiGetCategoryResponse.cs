using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetCategoryResponse
{
    public int Id { get; set; }
    public required MultiLangString Name { get; set; }
    public required RootCategory RootCategory { get; set; }
    public required string ImgUrl { get; set; }

    public static ApiGetCategoryResponse FromCategory(ProductCategory cat, Localizer localizer, UrlService urlService)
    {
        return new ApiGetCategoryResponse
        {
            Id = cat.Id,
            ImgUrl = urlService.MakeAbsolute(cat.ImgUrl),
            Name = localizer.MultiLangStringByKey(cat.NameKey),
            RootCategory = cat.RootCategory,
        };
    }
}


