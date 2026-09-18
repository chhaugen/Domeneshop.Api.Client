using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

[JsonConverter(typeof(JsonStringEnumConverter<StatusEnum>))]
public enum StatusEnum
{
    [JsonStringEnumMemberName("active")]
    Active,

    [JsonStringEnumMemberName("expired")]
    Expired,

    [JsonStringEnumMemberName("deactivated")]
    Deactivated,

    [JsonStringEnumMemberName("pendingDeleteRestorable")]
    PendingDeleteRestorable,
}
