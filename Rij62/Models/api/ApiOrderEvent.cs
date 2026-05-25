
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rij62.Models.Api;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ApiOrderAddedEvent), "orderAdded")]
[JsonDerivedType(typeof(ApiOrderItemStatusUpdatedEvent), "orderItemStatusUpdated")]
[JsonDerivedType(typeof(ApiOrderPaymentStatusUpdatedEvent), "orderPaymentStatusUpdated")]
public abstract record ApiOrderEvent
{
    public byte[] Serialize()
    {
        return Encoding.UTF8.GetBytes(JsonSerializer.Serialize(this));
    }
}

public record ApiOrderAddedEvent(ApiGetOrderResponse order) : ApiOrderEvent;
public record ApiOrderPaymentStatusUpdatedEvent(ApiGetOrderPaymentStatusResponse paymentStatus) : ApiOrderEvent;
public record ApiOrderItemStatusUpdatedEvent(ApiGetOrderItemStatusResponse orderItemStatus) : ApiOrderEvent;
