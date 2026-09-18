using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

[JsonConverter(typeof(JsonStringEnumConverter<InvoiceCurrencyEnum>))]
public enum InvoiceCurrencyEnum
{
    [JsonStringEnumMemberName("NOK")]
    NOK,

    [JsonStringEnumMemberName("SEK")]
    SEK,

    [JsonStringEnumMemberName("DKK")]
    DKK,

    [JsonStringEnumMemberName("GBP")]
    GBP,

    [JsonStringEnumMemberName("USD")]
    USD,
}
