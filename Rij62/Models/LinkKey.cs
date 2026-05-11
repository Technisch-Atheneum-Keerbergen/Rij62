
namespace Rij62.Models;


public class LinkKey
{
    public int Id { get; set; }
    public required Guid Key { get; set; }
    public required int UserId { get; set; }

    public required DateTimeOffset CreatedTime { get; set; }
}