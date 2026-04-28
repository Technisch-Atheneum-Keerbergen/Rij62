
namespace Rij62.Models.Api;

public class ApiPostOrderItem
{
    public int ProductId { get; set; }
    public required List<int> Choices { get; set; }
    public required int Quantity { get; set; }
}
