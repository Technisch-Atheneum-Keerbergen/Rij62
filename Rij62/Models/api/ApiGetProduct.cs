namespace Rij62.Models.Api;

public class ApiGetProduct
{

    public required int Id { get; set; }

    public required MultiLangString Title { get; set; }
    public required MultiLangString Description { get; set; }
    public required decimal Price { get; set; }
    public required int Btw { get; set; }
    public required int Stock { get; set; }

    public required bool IsAvailable { get; set; }
    public required string ImgURL { get; set; }
    public required int CategoryId { get; set; }

    public required List<ApiGetStep> Steps { get; set; }


    public static ApiGetProduct FromProduct(Product product, Localizer localizer, bool includeSteps = true)
    {
        if (includeSteps && product.Steps == null)
        {
            throw new ArgumentNullException("Product.Steps is null make shure you load it from the database");
        }
        var steps = new List<ApiGetStep>();
        if (includeSteps)
        {
            steps = product.Steps.Select((s) => ApiGetStep.FromProductStep(s, localizer)).ToList();
        }

        return new ApiGetProduct
        {
            Title = localizer.MultiLangStringByKey(product.TitleKey),
            Description = localizer.MultiLangStringByKey(product.DescriptionKey),
            Id = product.Id,
            Price = product.Price,
            Btw = product.Btw,
            Stock = product.Stock,
            IsAvailable = product.IsAvailable,
            ImgURL = product.ImgUrl,
            CategoryId = product.CategoryId,
            Steps = steps,
        };
    }
}


