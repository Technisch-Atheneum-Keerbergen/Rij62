
namespace Rij62;

public class ApiGetUserResponse
{
    public required int Id { get; set; }
    public required string DisplayName { get; set; }
    public required string? Email { get; set; }
    public required bool IsAdmin { get; set; }

    public static ApiGetUserResponse FromUser(User user)
    {
        return new ApiGetUserResponse
        {
            Id = user.Id,
            DisplayName = user.DisplayName,
            Email = user.Email,
            IsAdmin = user.IsAdmin
        };
    }
}
