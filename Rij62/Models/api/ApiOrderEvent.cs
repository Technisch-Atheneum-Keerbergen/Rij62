
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rij62.Models.Api;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ApiOrderAddedEvent), "orderAdded")]
[JsonDerivedType(typeof(ApiOrderItemStatusUpdatedEvent), "orderItemStatusUpdated")]
[JsonDerivedType(typeof(ApiOrderPaymentStatusUpdatedEvent), "orderPaymentStatusUpdated")]
public abstract class ApiOrderEvent
{
    public byte[] Serialize()
    {
        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(this, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        }));
    }
}

public class ApiOrderAddedEvent : ApiOrderEvent
{
    public ApiGetOrderResponse Order { get; set; }
    public ApiOrderAddedEvent(ApiGetOrderResponse order)
    {
        Order = order;
    }
}

public class ApiOrderItemStatusUpdatedEvent : ApiOrderEvent
{
    public ApiGetOrderItemStatusResponse OrderItemStatus { get; set; }
    public ApiOrderItemStatusUpdatedEvent(ApiGetOrderItemStatusResponse orderItemStatus)
    {
        OrderItemStatus = orderItemStatus;
    }
}

public class ApiOrderPaymentStatusUpdatedEvent : ApiOrderEvent
{
    public ApiGetOrderPaymentStatusResponse PaymentStatus { get; set; }

    public ApiOrderPaymentStatusUpdatedEvent(ApiGetOrderPaymentStatusResponse paymentStatus)
    {
        PaymentStatus = paymentStatus;
    }
}

