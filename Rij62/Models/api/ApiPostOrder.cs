namespace Rij62.Models.Api;

public class ApiPostOrder
{
    public int? TableNumber { get; set; }
    public long PickupTime { get; set; }
    public List<ApiPostOrderItem> Items { get; set; }
}
