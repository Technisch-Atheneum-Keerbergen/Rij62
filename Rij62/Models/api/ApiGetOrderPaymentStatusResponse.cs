
namespace Rij62.Models.Api;

public class ApiGetOrderPaymentStatusResponse
{
    public required PaymentStatus Status { get; set; }
    public required Guid orderId { get; set; }

    public static ApiGetOrderPaymentStatusResponse FromOrder(Order order)
    {
        return new ApiGetOrderPaymentStatusResponse
        {
            orderId = order.PublicId,
            Status = order.PaymentStatus,
        };
    }
}
