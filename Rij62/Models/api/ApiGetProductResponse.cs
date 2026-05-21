using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetProductResponse
{

    public required int Id { get; set; }

    public required MultiLangString Title { get; set; }
    public required MultiLangString Description { get; set; }
    public required decimal Price { get; set; }
    public required int Btw { get; set; }
    public required int Stock { get; set; }

    public required bool IsAvailable { get; set; }

    public required int? MenuPresetId { get; set; }
    public required bool EnabledByPreset { get; set; }
    public required string ImgURL { get; set; }
    public required int CategoryId { get; set; }

    public required List<ApiGetStepResponse> Steps { get; set; }


    public static ApiGetProductResponse FromProduct(Product product, MenuPresets presets, Localizer localizer, UrlService urlService, bool includeSteps = true)
    {
        if (includeSteps && product.Steps == null)
        {
            throw new ArgumentNullException("Product.Steps is null make shure you load it from the database");
        }
        var steps = new List<ApiGetStepResponse>();
        if (includeSteps)
        {
            steps = product.Steps.Select((s) => ApiGetStepResponse.FromProductStep(s, presets, localizer, urlService)).ToList();
        }

        return new ApiGetProductResponse
        {
            Title = localizer.MultiLangStringByKey(product.TitleKey),
            Description = localizer.MultiLangStringByKey(product.DescriptionKey),
            Id = product.Id,
            Price = product.Price,
            Btw = product.Btw,
            Stock = product.Stock,
            IsAvailable = product.IsAvailable,
            EnabledByPreset = presets.IsProductActive(product),
            MenuPresetId = product.MenuPresetId,
            ImgURL = urlService.MakeAbsolute(product.ImgUrl),
            CategoryId = product.CategoryId,
            Steps = steps,
        };
    }
}


