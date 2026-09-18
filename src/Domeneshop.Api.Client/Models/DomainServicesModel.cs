using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

/// <summary>
/// Domain services
/// </summary>
public record DomainServicesModel(
    [property: JsonPropertyName("registrar")]
    bool? Registrar = null,
    [property: JsonPropertyName("dns")]
    bool? Dns = null,
    [property: JsonPropertyName("email")]
    bool? Email = null,
    [property: JsonPropertyName("webhotel")]
    WebhotelEnum? Webhotel = null
    );
