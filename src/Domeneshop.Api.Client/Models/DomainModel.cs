using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

public record DomainModel(
    [property: JsonPropertyName("id")]
    int Id = 0,

    [property: JsonPropertyName("domain")]
    string? Domain = null,

    [property: JsonPropertyName("expiry_date")]
    DateOnly? ExpiryDate = null,

    [property: JsonPropertyName("registered_date")]
    DateOnly? RegisteredDate = null,

    [property: JsonPropertyName("renew")]
    bool? Renew = null,

    [property: JsonPropertyName("registrant")]
    string? Registrant = null,

    [property: JsonPropertyName("status")]
    string? Status = null,

    [property: JsonPropertyName("nameservers")]
    IReadOnlyList<string>? Nameservers = null,

    [property: JsonPropertyName("services")]
    DomainServicesModel? Services = null
    );
