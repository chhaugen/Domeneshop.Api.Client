using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

[JsonConverter(typeof(JsonStringEnumConverter<InvoiceTypeEnum>))]
public enum InvoiceTypeEnum
{
    [JsonStringEnumMemberName("invoice")]
    Invoice,

    [JsonStringEnumMemberName("credit_node")]
    CreditNode
}
