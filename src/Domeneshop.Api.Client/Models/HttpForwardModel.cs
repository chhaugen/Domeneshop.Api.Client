using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

public record HttpForwardModel(
    [property: JsonPropertyName("host")]
    string? Host = null,

    [property: JsonPropertyName("frame")]
    bool? Frame = null,

    [property: JsonPropertyName("url")]
    string? Url = null
    );
