
namespace Rij62.Models.Api;

public class ApiOrderItemStatusResponse
{
    public int OrderItemId { get; set; }
    public OrderStatus Status { get; set; }

    public static ApiOrderItemStatusResponse FromOrderItem(OrderItem orderItem)
    {
        return new ApiOrderItemStatusResponse { OrderItemId = orderItem.Id, Status = orderItem.Status };
    }
}
