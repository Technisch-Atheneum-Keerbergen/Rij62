
namespace Rij62.Models.Api;

public class ApiCreateUserResponse
{
    public required Guid LinkKey { get; set; }
    public required int Id { get; set; }
    public required ApiGetUserResponse User { get; set; }
}
