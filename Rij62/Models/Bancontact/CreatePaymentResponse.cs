
using System.Text.Json.Serialization;

namespace Rij62.Models.Bancontact;

public class CreatePaymentResponse
{
    [JsonPropertyName("paymentId")]
    public required string PaymentId { get; set; }

    [JsonPropertyName("_links")]
    public required LinksResponse Links { get; set; }

    public class LinksResponse
    {
        [JsonPropertyName("deeplink")]
        public required Link Deeplink { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("href")]
        public required string Href { get; set; }
    }
}
