
namespace Rij62.Models.Api;


public class ApiGetOrderItemChoice
{
    public required ApiGetOrderProduct Product { get; set; }

    public static ApiGetOrderItemChoice FromOrderItemChoice(OrderItemChoice choice, Localizer localizer)
    {
        return new ApiGetOrderItemChoice
        {
            Product = ApiGetOrderProduct.FromOrderProduct(choice.ChosenOrderProduct, localizer),
        };

    }
}
