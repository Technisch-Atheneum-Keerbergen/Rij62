
using Rij62.Services;

namespace Rij62.Models.Api;


public class ApiGetOrderItemChoiceResponse
{
    public required ApiGetOrderProductResponse Product { get; set; }

    public static ApiGetOrderItemChoiceResponse FromOrderItemChoice(OrderItemChoice choice, Localizer localizer, UrlService urlService)
    {
        return new ApiGetOrderItemChoiceResponse
        {
            Product = ApiGetOrderProductResponse.FromOrderProduct(choice.ChosenOrderProduct, localizer, urlService),
        };

    }
}
