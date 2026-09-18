using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

[JsonConverter(typeof(JsonStringEnumConverter<RecordTypeEnum>))]
public enum RecordTypeEnum
{
    [JsonStringEnumMemberName("A")]
    A,

    [JsonStringEnumMemberName("AAAA")]
    AAAA,

    [JsonStringEnumMemberName("CNAME")]
    CNAME,

    [JsonStringEnumMemberName("MX")]
    MX,

    [JsonStringEnumMemberName("SRV")]
    SRV,

    [JsonStringEnumMemberName("TLSA")]
    TLSA,

    [JsonStringEnumMemberName("TXT")]
    TXT,

}
