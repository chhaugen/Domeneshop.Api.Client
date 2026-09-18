using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

[JsonConverter(typeof(JsonStringEnumConverter<WebhotelEnum>))]
public enum WebhotelEnum
{
    [JsonStringEnumMemberName("none")]
    None,

    [JsonStringEnumMemberName("webmedium")]
    WebMedium,

    [JsonStringEnumMemberName("websmall")]
    WebSmall,

    [JsonStringEnumMemberName("weblarge")]
    WebLarge,

    [JsonStringEnumMemberName("webxlarge")]
    WebXLarge,
}
