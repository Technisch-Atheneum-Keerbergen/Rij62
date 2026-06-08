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
        public required int? TimeSlotId { get; set; }
        public required int? TableNumber { get; set; }
        public required string? Comment { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public bool IsPickedUp()
        {
            return OrderItems.All((o) => o.Status != OrderStatus.PickedUp);
        }

        public static Order FromApiPostOrder(ApiCreateOrderRequest order, TimeSlots timeSlots)
        {
            TimeSlot? timeSlot = null;
            if (order.TimeSlotId != null)
            {
                timeSlot = timeSlots.GetSlot(order.TimeSlotId.Value);
                if (timeSlot == null)
                {
                    throw new Exception("BUG: Trying to create order with a timeslot that doesn't exist (should have been caught by validation)");
                }
            }


            var now = DateTime.UtcNow;
            var pickupTime = now;
            if (timeSlot != null)
            {
                pickupTime = new DateTime(DateOnly.FromDateTime(now), TimeOnly.FromTimeSpan(TimeSpan.FromSeconds(timeSlot.StartTime)));
            }
            return new Order
            {
                Id = 0,
                PublicId = Guid.NewGuid(),
                CreatedTime = new DateTimeOffset(now),
                PickupTime = new DateTimeOffset(pickupTime),
                TimeSlotId = order.TimeSlotId,
                TableNumber = order.TableNumber,
                PaymentStatus = PaymentStatus.NotPaid,
                PaymentId = null,
                Comment = order.Comment,
            };

        }
    }

}
