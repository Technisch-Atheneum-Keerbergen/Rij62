using System.ComponentModel.DataAnnotations.Schema;

namespace Rij62.Models;

public class OrderItemChoice
{
    public int Id { get; set; }

    public required int OrderItemId { get; set; }
    public required int ChosenOrderProductId { get; set; }

    public required int StepNumber { get; set; }

    [ForeignKey("OrderItemId")]
    public OrderItem OrderItem { get; set; }

    [ForeignKey("ChosenOrderProductId")]
    public OrderProduct ChosenOrderProduct { get; set; }

    public static OrderItemChoice[] FromOrderItemsAndChoice(OrderItem[] orderItems, OrderProduct choice)
    {
        var output = new OrderItemChoice[orderItems.Length];
        for (int i = 0; i < orderItems.Length; i++)
        {
            output[i] = new OrderItemChoice
            {
                ChosenOrderProductId = choice.Id,
                OrderItemId = orderItems[i].Id,
                StepNumber = 0, // We may in the future use this.
            };
        }
        return output;

    }
}
