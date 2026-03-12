using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rij62.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description {get; set;}
        public int TableNumber { get; set; }
        public int Price { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}