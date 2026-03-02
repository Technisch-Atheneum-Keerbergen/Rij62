// **********************************
//     *** Order Model  ***
// Author: Xavier Demaerel
// Date: 02/03/2026
// File: Models/Order.cs
// **********************************
namespace Rij62.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime PickupTime { get; set; }
        public required string Status { get; set; }
    }

}
