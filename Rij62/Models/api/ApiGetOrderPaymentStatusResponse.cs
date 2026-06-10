
namespace Rij62.Models.Api;

public class ApiGetOrderPaymentStatusResponse
{
    public required PaymentStatus Status { get; set; }
    public required Guid OrderId { get; set; }


    public static ApiGetOrderPaymentStatusResponse FromOrderIdAndStatus(Guid orderId, PaymentStatus status)
    {
        return new ApiGetOrderPaymentStatusResponse
        {
            OrderId = orderId,
            Status = status,
        };
    }

    public static ApiGetOrderPaymentStatusResponse FromOrder(Order order)
    {
        return new ApiGetOrderPaymentStatusResponse
        {
            OrderId = order.PublicId,
            Status = order.PaymentStatus,
        };
    }
}
