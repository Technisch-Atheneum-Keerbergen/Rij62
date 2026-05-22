
namespace Rij62.Models.Api;

public class ApiCreateOrderItemRequest
{
    public int ProductId { get; set; }
    public required List<int> Choices { get; set; }
    public required int Quantity { get; set; }

    public string? Comment {get; set;}
}
