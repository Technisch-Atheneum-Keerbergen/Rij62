using Rij62.Models.Api;
using Rij62.Services;
namespace Rij62.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }

        public required Guid PublicId { get; set; } // Use a UUID for the client side so other people can't guess order ID's.
        public required string? PaymentId { get; set; }
        public required PaymentStatus PaymentStatus { get; set; }
        public required DateTimeOffset CreatedTime { get; set; }
        public required DateTimeOffset PickupTime { get; set; }
        public required int? TableNumber { get; set; }
        public required string? Comment { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public static Order FromApiPostOrder(ApiCreateOrderRequest order)
        {
            var now = DateTimeOffset.Now.ToUniversalTime();
            return new Order
            {
                Id = 0,
                PublicId = Guid.NewGuid(),
                CreatedTime = now,
                PickupTime = order.PickupTime != null ? DateTimeOffset.FromUnixTimeSeconds(order.PickupTime.Value) : now,
                TableNumber = order.TableNumber,
                PaymentStatus = PaymentStatus.NotPaid,
                PaymentId = null,
                Comment = order.Comment,
            };

        }
    }

}
