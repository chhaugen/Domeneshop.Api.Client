using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

public record AddDnsRecordResponseModel(
    [property: JsonPropertyName("id")] int Id);
