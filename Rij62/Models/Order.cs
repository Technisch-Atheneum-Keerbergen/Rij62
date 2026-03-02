namespace Rij62.Models
{
    public class Order
    {
        
        public int Id { get; set; }
        public int TableId { get; set; }
        public int PickupTime { get; set; }
        public string Status { get; set; }

    }
}