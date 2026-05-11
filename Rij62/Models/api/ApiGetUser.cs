
namespace Rij62;

public class ApiGetUser
{
    public required int Id { get; set; }
    public required string DisplayName { get; set; }
    public required string? Email { get; set; }
    public required bool IsAdmin { get; set; }

    public static ApiGetUser FromUser(User user)
    {
        return new ApiGetUser
        {
            Id=user.Id,
            DisplayName=user.DisplayName,
            Email=user.Email,
            IsAdmin=user.IsAdmin
        };
    }
}