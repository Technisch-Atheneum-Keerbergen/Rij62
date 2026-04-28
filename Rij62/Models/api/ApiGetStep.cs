using Rij62.Services;
using Microsoft.Net.Http.Headers;

namespace Rij62.Models.Api;

public class ApiGetStep
{
    public required int Id { get; set; }
    public required MultiLangString Title { get; set; }
    public required bool MultipleChoice { get; set; }
    public int? DefaultOptionId { get; set; }
    public required List<ApiGetProduct> Options { get; set; }


    public static ApiGetStep FromProductStep(ProductStep step, MenuPresetService presetService, Localizer localizer)
    {
        if (step.Options == null)
        {
            throw new ArgumentNullException("ProductStep.Options is null make shure you load it from the database");

        }
        return new ApiGetStep
        {
            Id = step.Id,
            Title = localizer.MultiLangStringByKey(step.TitleKey),
            MultipleChoice = step.MultipleChoice,
            DefaultOptionId = step.DefaultOptionId,
            Options = step.Options.Select((o) =>
            {
                if (o.Product == null)
                {
                    throw new ArgumentNullException("ProductStepOption.Product is null make shure you load it from the database");
                }
                return ApiGetProduct.FromProduct(o.Product, presetService, localizer, false);
            }).ToList(),
        };
    }
}
