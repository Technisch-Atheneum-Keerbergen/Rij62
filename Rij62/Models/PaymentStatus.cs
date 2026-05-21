
using System.Text.Json.Serialization;

namespace Rij62.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PaymentStatus
{
    NotPaid,
    Success,
    Failed
}
