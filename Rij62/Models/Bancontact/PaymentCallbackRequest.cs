

namespace Rij62.Models.Bancontact;

public class PaymentCallbackRequest
{
    public required string PaymentId { get; set; }

    public required string Status { get; set; }
}
