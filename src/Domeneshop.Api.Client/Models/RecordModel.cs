using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

/// <summary>
/// DNS Record
/// </summary>
/// <param name="Id">ID of DNS record</param>
/// <param name="Host">The host/subdomain the DNS record applies to</param>
/// <param name="TimeToLiveSeconds">TTL of DNS record in seconds. Must be a multiple of 60.</param>
/// <param name="Type"></param>
/// <param name="Data">
/// A: IPv4 address<br/>
/// AAAA: IPv6 address<br/>
/// CNAME: The target hostname<br/>
/// MX: The target MX host.<br/>
/// SRV: The target hostname<br/>
/// TLSA: TLSA hash. Lenght depends on dtype (SHA-256 = 64 characters, SHA-512 = 128 characters)<br/>
/// TXT: Freeform text field.
/// </param>
/// <param name="Priority">
/// MX: MX record priority, also known as preference. Lower values are usually preferred first, but this is not guaranteed<br/>
/// SRV: SRV record priority, also known as preference. Lower values are usually preferred first
/// </param>
/// <param name="Weight">SRV record weight. Relevant if multiple records have same preference</param>
/// <param name="Port">SRV record port. The port where the service is found.</param>
/// <param name="Usage">TLSA usage. Indicates how the cryptographic hash should be interpreted (0 = PKIX-TA, certificate authority; 1 = PKIX-EE, service certificate; 2 = DANE-TA, trust anchor, 3 = DANE-EE, domain issued)</param>
/// <param name="Selector">TLSA selector. Where the hash is taken from (0 = entire certificate blob; 1 = DER format)</param>
/// <param name="Dtype">TLSA matching type. Indicates hashing algorithm. (0 = exact match; 1 = SHA-256; 2 = SHA-512)</param>
public record RecordModel(
    [property: JsonPropertyName("id")]
    int Id = 0,

    [property: JsonPropertyName("host")]
    string? Host = null,

    [property: JsonPropertyName("ttl")]
    short TimeToLiveSeconds = 3600,

    [property: JsonPropertyName("type")]
    RecordTypeEnum Type = default,

    [property: JsonPropertyName("data")]
    string? Data = null,

    [property: JsonPropertyName("priority")]
    short? Priority = null,

    [property: JsonPropertyName("weight")]
    short? Weight = null,

    [property: JsonPropertyName("port")]
    short? Port = null,

    [property: JsonPropertyName("usage")]
    short? Usage = null,

    [property: JsonPropertyName("selector")]
    short? Selector = null,

    [property: JsonPropertyName("dtype")]
    short? Dtype = null
    );
