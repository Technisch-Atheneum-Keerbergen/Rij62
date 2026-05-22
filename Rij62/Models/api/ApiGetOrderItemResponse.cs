using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetOrderItemResponse
{
    public required int Id { get; set; }
    public required ApiGetOrderProductResponse Product { get; set; }
    public required OrderStatus Status { get; set; }
    public required int Quantity { get; set; }

    public required string? Comment { get; set; }

    public required List<ApiGetOrderItemChoiceResponse> Choices { get; set; }

    public static ApiGetOrderItemResponse FromOrderItem(OrderItem orderItem, Localizer localizer, UrlService urlService)
    {
        if (orderItem.OrderProduct == null)
        {
            throw new ArgumentNullException("OrderItem.OrderProduct is null make shure you load it from the database");
        }
        if (orderItem.Choices == null)
        {
            throw new ArgumentNullException("OrderItem.Choices is null make shure you load it from the database");
        }

        return new ApiGetOrderItemResponse
        {
            Id = orderItem.Id,
            Status = orderItem.Status,
            Quantity = orderItem.Quantity,
            Comment = orderItem.Comment,
            Product = ApiGetOrderProductResponse.FromOrderProduct(orderItem.OrderProduct, localizer, urlService),
            Choices = orderItem.Choices.Select((c) => ApiGetOrderItemChoiceResponse.FromOrderItemChoice(c, localizer, urlService)).ToList()
        };
    }
}

