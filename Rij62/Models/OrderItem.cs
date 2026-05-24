using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rij62.Models.Api;

namespace Rij62.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public required int OrderId { get; set; }
        public required int OrderProductId { get; set; }

        public required OrderStatus Status { get; set; }
        public required string? Comment { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("OrderProductId")]
        public OrderProduct OrderProduct { get; set; }


        public IEnumerable<OrderItemChoice> Choices { get; set; }


        public static async Task<OrderItem[]> FromApiPostOrderItem(ApiCreateOrderItemRequest apiOrderItem, int orderId, int orderProductId)
        {
            var items = new OrderItem[apiOrderItem.Quantity];
            for (int i = 0; i < apiOrderItem.Quantity; i++)
            {
                items[i] = new OrderItem
                {
                    OrderId = orderId,
                    OrderProductId = orderProductId,
                    Status = OrderStatus.Pending,
                    Comment = apiOrderItem.Comment,
                };
            }
            return items;
        }
    }
}
