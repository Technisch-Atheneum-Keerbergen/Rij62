namespace Rij62.Models.Api;

public class ApiCreateOrderRequest
{
    public int? TableNumber { get; set; }
    public long? PickupTime { get; set; }
    public List<ApiCreateOrderItemRequest> Items { get; set; }
}
