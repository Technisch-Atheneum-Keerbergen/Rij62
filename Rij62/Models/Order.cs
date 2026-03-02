// **********************************
//     *** Order Model  ***
// Author: Xavier Demaerel
// Date: 02/03/2026
// File: Models/Order.cs
// **********************************

using System.ComponentModel.DataAnnotations.Schema;
namespace Rij62.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PickupTime { get; set; }
        public string Status { get; set; }
        public int TableId { get; set; }

        [ForeignKey("TableId")]
        public Table Table {get; set;}

        public ICollection<OrderItem> OrderItems {get; set;}
    }

}
