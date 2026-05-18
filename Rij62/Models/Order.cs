using Rij62.Models.Api;
namespace Rij62.Models
{
    public class Order
    {
        public required string? PaymentId { get; set; }
        public required bool PaymentComplete { get; set; }
        public int Id { get; set; }
        public Guid PublicId { get; set; } // Use a UUID for the client side so other people can't guess order ID's.
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset PickupTime { get; set; }
        public int? TableNumber { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public static Order FromApiPostOrder(ApiPostOrder order)
        {
            var now = DateTimeOffset.Now.ToUniversalTime();
            return new Order
            {
                Id = 0,
                PublicId = Guid.NewGuid(),
                CreatedTime = now,
                PickupTime = order.PickupTime != null ? DateTimeOffset.FromUnixTimeSeconds(order.PickupTime.Value) : now,
                TableNumber = order.TableNumber,
                PaymentComplete = false,
                PaymentId = null,
            };

        }
    }

}
