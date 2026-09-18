using Refit;
using System.Text.Json;

namespace Chhaugen.Domeneshop.Api.Client;

public static class DomeneshopRefitSettings
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web)
    {
        TypeInfoResolver = DomeneshopJsonSerializerContext.Default
    };

    public static RefitSettings ApplyDefaults(this RefitSettings refitSettings)
    {
        refitSettings.ContentSerializer = new SystemTextJsonContentSerializer(_jsonSerializerOptions);
        return refitSettings;
    }

    public static RefitSettings Default => field ??= new RefitSettings().ApplyDefaults();
}
