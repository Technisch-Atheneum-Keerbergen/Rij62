
using Rij62.Services;

namespace Rij62.Models.Api;


public class ApiGetOrderProduct
{
    public required int ProductId { get; set; }
    public required MultiLangString Title { get; set; }
    public required MultiLangString Description { get; set; }
    public required decimal Price { get; set; }
    public required int Btw { get; set; }
    public required string ImgUrl { get; set; }

    public static ApiGetOrderProduct FromOrderProduct(OrderProduct product, Localizer localizer, UrlService urlService)
    {
        return new ApiGetOrderProduct
        {
            ProductId = product.ProductId,
            Title = localizer.MultiLangStringByKey(product.TitleKey),
            Description = localizer.MultiLangStringByKey(product.DescriptionKey),
            Price = product.Price,
            Btw = product.Btw,
            ImgUrl = urlService.MakeAbsolute(product.ImgUrl)

        };
    }
}
