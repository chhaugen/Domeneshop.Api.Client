using Refit;

namespace Chhaugen.Domeneshop.Api.Client;

/// <summary>
/// This group exposes endpoints that can be used by certain Dynamic DNS implementations found in consumer routers appliances.
/// </summary>
public interface IDdnsEndpoints
{
    /// <summary>
    /// Update DNS using the "IP update protocol".<br/>
    /// <br/>
    /// A DNS record for the given hostname will be created if it does not exist, or updated if it does. The record<br/>
    /// type (`A` or `AAAA` will automatically be detected).<br/>
    /// <br/>
    /// If the DDNS implementation does not allow you to specify authentication, it can usually be specified inline<br/>
    /// in the URL:<br/>
    /// <br/>
    /// ```<br/>
    /// https://{token}:{secret}@api.domeneshop.no/v0/dyndns/update?hostname=example.com&amp;myip=127.0.0.1<br/>
    /// ```
    /// </summary>
    /// <param name="hostname">The fully qualified domain (FQDN) to be updated, without trailing dot. Multiple hostnames may be provided, delimited by commas</param>
    /// <param name="myIP">The new IPv4 or IPv6 address to set. If not provided, the IP of the client making the API request will be used. Multiple IPv4 and IPv6 addresses (up to 9) can be provided, delimited by commas.</param>
    /// <param name="cancellationToken"></param>
    [Get("/dyndns/update")]
    Task DdnsUpdateAsync(string hostname, [AliasAs("myip")] string? myIP = null, CancellationToken cancellationToken = default);
}
