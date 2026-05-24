
namespace Rij62.Models.Api;

public class ApiGetOrderItemStatusResponse
{
    public required int OrderItemId { get; set; }
    public required OrderStatus Status { get; set; }

    public static ApiGetOrderItemStatusResponse FromOrderItem(OrderItem orderItem)
    {
        return new ApiGetOrderItemStatusResponse { OrderItemId = orderItem.Id, Status = orderItem.Status };
    }
}
