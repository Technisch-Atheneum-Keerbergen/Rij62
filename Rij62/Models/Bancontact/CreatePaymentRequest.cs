

using System.Text.Json.Serialization;

namespace Rij62.Models.Bancontact;

public class CreatePaymentRequest
{

    public required string Reference { get; set; }
    public required int Amount { get; set; }
    public required string Currency { get; set; }
    public required string Description { get; set; }
    public required string CallbackUrl { get; set; }
    public required string ReturnUrl { get; set; }

}
