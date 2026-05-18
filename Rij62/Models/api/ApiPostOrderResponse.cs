
using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiPostOrderResponse
{
    public required List<OrderValidationError> ValidationErrors { get; set; }

    public Guid? OrderId { get; set; }

}
