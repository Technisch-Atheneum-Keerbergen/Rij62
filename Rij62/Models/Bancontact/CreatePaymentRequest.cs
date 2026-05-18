

using System.Text.Json.Serialization;

namespace Rij62.Models.Bancontact;

public class CreatePaymentRequest
{

    public required string Reference { get; set; }
    public required string BulkId { get; set; }
    public required string Amount { get; set; } // This should be a string
    public required string Currency { get; set; }
    public required string Description { get; set; }
    public required string IdentifyCallbackUrl { get; set; }
    public required string CallbackUrl { get; set; }
    public required string ReturnUrl { get; set; }

}
