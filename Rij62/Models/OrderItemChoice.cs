using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Rij62.Models;

public class OrderItemChoice
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public int OrderItemId { get; set; }
    public int ChosenProductId { get; set; }

    [ForeignKey("OrderItemId")]
    public OrderItem OrderItem { get; set; }
}
