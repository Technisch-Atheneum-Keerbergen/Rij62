using Microsoft.AspNetCore.Http.Features;
using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetOrder
{
    public Guid Id { get; set; }
    public int? TableNumber { get; set; }
    public long CreatedTime { get; set; }
    public long PickupTime { get; set; }
    public required PaymentStatus PaymentStatus { get; set; }
    public List<ApiGetOrderItem> Items { get; set; }

    public static ApiGetOrder FromOrder(Order order, Localizer localizer, UrlService urlService)
    {
        var items = order.OrderItems.Select((i) => ApiGetOrderItem.FromOrderItem(i, localizer, urlService));
        return new ApiGetOrder
        {
            Id = order.PublicId,
            TableNumber = order.TableNumber,
            PaymentStatus = order.PaymentComplete,
            CreatedTime = order.CreatedTime.ToUnixTimeSeconds(),
            PickupTime = order.PickupTime.ToUnixTimeSeconds(),
            Items = items.ToList(),

        };
    }
}
