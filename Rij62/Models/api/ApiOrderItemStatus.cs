
namespace Rij62.Models.Api;

public class ApiOrderItemStatus
{
    public int OrderItemId { get; set; }
    public OrderStatus Status { get; set; }

    public static ApiOrderItemStatus FromOrderItem(OrderItem orderItem)
    {
        return new ApiOrderItemStatus {OrderItemId=orderItem.Id, Status=orderItem.Status};
    }
}