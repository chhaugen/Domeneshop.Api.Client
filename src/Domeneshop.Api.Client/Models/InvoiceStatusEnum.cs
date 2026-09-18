using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

[JsonConverter(typeof(JsonStringEnumConverter<InvoiceStatusEnum>))]
public enum InvoiceStatusEnum
{
    [JsonStringEnumMemberName("unpaid")]
    Unpaid,

    [JsonStringEnumMemberName("paid")]
    Paid,

    [JsonStringEnumMemberName("settled")]
    Settled
}
