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
}
