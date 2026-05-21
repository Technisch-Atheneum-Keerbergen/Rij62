
using Newtonsoft.Json;

namespace Rij62.Models.Bancontact;

public class CreatePaymentResponse
{
    public required string PaymentId { get; set; }

    [JsonProperty("_links")]
    public required LinksResponse Links { get; set; }
    public class LinksResponse
    {
        public string Deeplink { get; set; }
    }
}
