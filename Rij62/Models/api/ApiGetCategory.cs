namespace Rij62.Models.Api;

public class ApiGetCategory
{
    public int Id { get; set; }
    public required MultiLangString Name { get; set; }
    public required RootCategory RootCategory { get; set; }
    public required string ImgUrl { get; set; }

    public static ApiGetCategory FromCategory(ProductCategory cat, Localizer localizer)
    {
        return new ApiGetCategory
        {
            Id = cat.Id,
            ImgUrl = cat.ImgUrl,
            Name = localizer.MultiLangStringByKey(cat.NameKey),
            RootCategory = cat.RootCategory,
        };
    }
}


