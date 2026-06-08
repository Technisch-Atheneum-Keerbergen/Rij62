namespace Rij62.Models.Api;

public class ApiCreateOrderRequest
{
    public int? TableNumber { get; set; }
    public int? TimeSlotId { get; set; }
    public List<ApiCreateOrderItemRequest> Items { get; set; }

    public string? Comment { get; set; }
}
