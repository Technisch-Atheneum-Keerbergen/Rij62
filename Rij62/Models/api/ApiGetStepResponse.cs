using Rij62.Services;
using Microsoft.Net.Http.Headers;

namespace Rij62.Models.Api;

public class ApiGetStepResponse
{
    public required int Id { get; set; }
    public required MultiLangString Title { get; set; }
    public required bool MultipleChoice { get; set; }
    public int? DefaultOptionId { get; set; }
    public required List<ApiGetProductResponse> Options { get; set; }


    public static ApiGetStepResponse FromProductStep(ProductStep step, MenuPresets presets, Localizer localizer, UrlService urlService)
    {
        if (step.Options == null)
        {
            throw new ArgumentNullException("ProductStep.Options is null make sure you load it from the database");

        }
        return new ApiGetStepResponse
        {
            Id = step.Id,
            Title = localizer.MultiLangStringByKey(step.TitleKey),
            MultipleChoice = step.MultipleChoice,
            DefaultOptionId = step.DefaultOptionId,
            Options = step.Options.Select((o) =>
            {
                if (o.Product == null)
                {
                    throw new ArgumentNullException("ProductStepOption.Product is null make sure you load it from the database");
                }
                return ApiGetProductResponse.FromProduct(o.Product, presets, localizer, urlService, false);
            }).ToList(),
        };
    }
}
