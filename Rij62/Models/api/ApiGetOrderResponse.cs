using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetOrderResponse
{
    public required Guid Id { get; set; }
    public required int? TableNumber { get; set; }
    public required long CreatedTime { get; set; }
    public required long PickupTime { get; set; }
    public required int OrderNumber { get; set; }
    public required PaymentStatus PaymentStatus { get; set; }

    public required string? Comment { get; set; }
    public List<ApiGetOrderItemResponse> Items { get; set; }

    public static ApiGetOrderResponse FromOrder(Order order, Localizer localizer, UrlService urlService)
    {
        var items = order.OrderItems.Select((i) => ApiGetOrderItemResponse.FromOrderItem(i, localizer, urlService));
        return new ApiGetOrderResponse
        {
            Id = order.PublicId,
            TableNumber = order.TableNumber,
            PaymentStatus = order.PaymentStatus,
            CreatedTime = order.CreatedTime.ToUnixTimeSeconds(),
            PickupTime = order.PickupTime.ToUnixTimeSeconds(),
            Items = items.ToList(),
            Comment = order.Comment,
            OrderNumber = order.OrderNumber,
        };
    }
}
