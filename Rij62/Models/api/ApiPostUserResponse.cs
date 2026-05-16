
namespace Rij62.Models.Api;

public class ApiPostUserResponse
{
    public required Guid LinkKey { get; set; }
    public required int Id { get; set; }
    public required ApiGetUser User { get; set; }
}
