using Chhaugen.Domeneshop.Api.Client.Models;
using Microsoft.Extensions.Configuration.UserSecrets;
using Refit;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using static System.Console;

namespace Chhaugen.Domeneshop.Api.Client.Playground;

internal class Program
{
    static async Task Main(string[] args)
    {
        string token = "";
        string secret = "";
        if (args.Length >= 2)
        {
            token = args[0];
            secret = args[1];
        }
        else
        {
            var assembly = Assembly.GetEntryAssembly(); // or typeof(Program).Assembly
            var attribute = assembly?.GetCustomAttribute<UserSecretsIdAttribute>();
            var secretsFilePath = PathHelper.GetSecretsPathFromSecretsId(attribute?.UserSecretsId);

            await using var secretsFile = File.OpenRead(secretsFilePath);
            var jsonNode = await JsonNode.ParseAsync(secretsFile)
                ?? throw new InvalidOperationException("Could not deserialize secrets.");
            var jsonObject = jsonNode.AsObject();
            if (jsonObject.TryGetPropertyValue("Token", out var tokenNode))
                token = tokenNode!.GetValue<string>();
            if (jsonObject.TryGetPropertyValue("Secret", out var secretNode))
                secret = secretNode!.GetValue<string>();
        }
        
        var tokenSecret = Encoding.UTF8.GetBytes($"{token}:{secret}");

        var httpClient = new HttpClient()
        {
            BaseAddress = new("https://api.domeneshop.no/v0"),
            DefaultRequestHeaders =
            {
                Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(tokenSecret))
            }
        };

        var domeneshopApi = RestService.ForGenerated<IDomeneshopEndpoints>(httpClient, DomeneshopRefitSettings.Default);

        // Domains
        var domains = await domeneshopApi.ListDomainsAsync();
        WriteJson(domains);

        var domain = await domeneshopApi.FindDomainByIdAsync(domainId: domains[0].Id);
        WriteJson(domain);

        // DNS

        var records = await domeneshopApi.ListDnsRecordsAsync(domain.Id);
        WriteJson(records);

        var host = $"{nameof(Domeneshop)}{nameof(Api)}{nameof(Client)}{nameof(Playground)}".ToLower();

        var recordId = records
            .Where(x => x.Host == host)
            .Select(x => x.Id)
            .FirstOrDefault();

        
        if (recordId == default)
        {
            var newRecord = new RecordModel()
            {
                Host = host,
                TimeToLiveSeconds = 60,
                Type = RecordTypeEnum.A,
                Data = "127.0.0.1"
            };
            WriteJson(newRecord);

            var newRecordResponse = await domeneshopApi.AddDnsRecordAsync(domain.Id, newRecord);
            recordId = newRecordResponse.Id;
            WriteJson(newRecordResponse);
        }

        var record = await domeneshopApi.FindDnsRecordByIdAsync(domain.Id, recordId);

        record = record with { Data = "127.0.0.2" };
        await domeneshopApi.UpdateDnsRecordByIdAsync(domain.Id, recordId, record);

        await domeneshopApi.DeleteDnsRecordByIdAsync(domain.Id, recordId);

        // DDNS

        var fqdn = $"{host}.{domain.Domain}".ToLower();
        var myIPs = "127.0.0.1";
        await domeneshopApi.DdnsUpdateAsync(fqdn, myIPs);

        var ddnsRecords = (await domeneshopApi.ListDnsRecordsAsync(domain.Id, host: host));
        WriteJson(ddnsRecords);

        foreach(var ddnsRecord in ddnsRecords)
            await domeneshopApi.DeleteDnsRecordByIdAsync(domain.Id, ddnsRecord.Id);

        // HTTP Forwards

        var forwards = await domeneshopApi.ListForwardsAsync(domain.Id);
        WriteJson(forwards);

        if (!forwards.Any(x => x.Host == host))
        {
            var newForward = new HttpForwardModel()
            {
                Host = host,
                Url = $"https://{domain.Domain}"
            };

            await domeneshopApi.AddForwardAsync(domain.Id, newForward);
        }

        var forward = await domeneshopApi.FindForwardByHostAsync(domain.Id, host);

        // Cannot change host
        forward = forward with { Url = $"https://{domain.Domain}/lol" };

        await domeneshopApi.UpdateForwardByHostAsync(domain.Id, host, forward);

        await domeneshopApi.DeleteForwardByHostAsync(domain.Id, host);

        // Invoices
    }

    private static readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true,
    };
    private static readonly JsonSerializerContext _jsonSerializerContext = new DomeneshopJsonSerializerContext(_jsonSerializerOptions);

    private static void WriteJson<T>(T @object, [CallerArgumentExpression(nameof(@object))] string variableName = "")
    {
        var variableNameTrue = new string([.. variableName.TakeWhile(char.IsLetterOrDigit)]);
        var json = JsonSerializer.Serialize(@object, typeof(T), _jsonSerializerContext);
        WriteLine($"{variableNameTrue}: {json}");
    }
}
