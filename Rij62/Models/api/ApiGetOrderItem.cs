using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetOrderItem
{
    public required int Id { get; set; }
    public required ApiGetOrderProduct Product { get; set; }
    public required OrderStatus Status { get; set; }
    public required int Quantity { get; set; }

    public required List<ApiGetOrderItemChoice> Choices { get; set; }

    public static ApiGetOrderItem FromOrderItem(OrderItem orderItem, Localizer localizer, UrlService urlService)
    {
        if (orderItem.OrderProduct == null)
        {
            throw new ArgumentNullException("OrderItem.OrderProduct is null make shure you load it from the database");
        }
        if (orderItem.Choices == null)
        {
            throw new ArgumentNullException("OrderItem.Choices is null make shure you load it from the database");
        }

        return new ApiGetOrderItem
        {
            Id = orderItem.Id,
            Status = orderItem.Status,
            Quantity = orderItem.Quantity,
            Product = ApiGetOrderProduct.FromOrderProduct(orderItem.OrderProduct, localizer, urlService),
            Choices = orderItem.Choices.Select((c) => ApiGetOrderItemChoice.FromOrderItemChoice(c, localizer, urlService)).ToList()
        };
    }
}

