using Microsoft.AspNetCore.Http.Features;
using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetOrder
{
    public int Id {get; set;}
    public int TableNumber {get; set;}
    public long CreatedTime {get; set;}
    public long PickupTime {get; set;}

    public List<ApiGetOrderItem> Items {get; set;}

    public static ApiGetOrder FromOrder(Order order, Localizer localizer)
    {
        var items = order.OrderItems.Select((i) => ApiGetOrderItem.FromOrderItem(i, localizer));
        return new ApiGetOrder
        {
            Id= order.Id,
            TableNumber =order.TableNumber,
            CreatedTime=order.CreatedTime.ToUnixTimeSeconds(),
            PickupTime=order.PickupTime.ToUnixTimeSeconds(),
            Items=items.ToList(),

        };
    }
}