using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rij62.Models
{
    public class OrderItem
    {
        int Id { get; set; }
        string Title { get; set; }
        string Description {get; set;}
        int TableNumber { get; set; }
        int Price { get; set; }
        int OrderId { get; set; }
        [ForeignKey("OrderId")]
        Order Order { get; set; }
    }
}