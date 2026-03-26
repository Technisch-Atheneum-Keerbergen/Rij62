// **********************************
//     *** Order Model  ***
// Author: Xavier Demaerel
// Date: 02/03/2026
// File: Models/Order.cs
// **********************************

using System.ComponentModel.DataAnnotations.Schema;
using Rij62.Models.Api;
namespace Rij62.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset PickupTime { get; set; }
        public int? TableNumber { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public static Order FromApiPostOrder(ApiPostOrder order)
        {
            return new Order
            {
                Id = 0,
                CreatedTime = DateTimeOffset.Now.ToUniversalTime(),
                PickupTime = DateTimeOffset.FromUnixTimeSeconds(order.PickupTime),
                TableNumber = order.TableNumber
            };

        }
    }

}
