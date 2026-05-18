using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rij62.Services;

namespace Rij62.Models
{
    public class OrderItem
    {
        [Key]
        public required int Id { get; set; }

        public required int OrderId { get; set; }
        public required int OrderProductId { get; set; }

        public required OrderStatus Status { get; set; }
        public required int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("OrderProductId")]
        public OrderProduct OrderProduct { get; set; }


        public IEnumerable<OrderItemChoice> Choices { get; set; }


        public static async Task<OrderItem> FromApiPostOrderItem(int OrderId)
        {
            return new OrderItem
            {
                Id = 0,
                OrderId = OrderId,
                Status = OrderStatus.Pending,
                Quantity = 1,
            };
        }
    }
}
