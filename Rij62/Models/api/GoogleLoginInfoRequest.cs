namespace Rij62.Models.Api;
public class GoogleLoginInfoRequest
{
    public required string Token { get; set; }

    // Use this link key to link the google account of the login to a user.
    public Guid? LinkKey { get; set; }
}
