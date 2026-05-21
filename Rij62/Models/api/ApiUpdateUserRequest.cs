namespace Rij62.Models.Api;

public class ApiUpdateUserRequest
{
    public required string DisplayName { get; set; }
    public required bool IsAdmin { get; set; }
}
