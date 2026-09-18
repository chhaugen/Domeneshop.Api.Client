using Chhaugen.Domeneshop.Api.Client.Models;
using Refit;

namespace Chhaugen.Domeneshop.Api.Client;

/// <summary>
/// These endpoints allow you to list, create and delete HTTP forwards (\"WWW forwarding\") for any domain
/// that has active DNS service.
/// 
/// While frame forwards (an &lt;iframe&gt; embed) are supported through setting the `frame` field, we strongly
/// discourage the use of these. Use DNS records instead.
/// </summary>
public interface IHttpForwardsEndpoints
{
    /// <summary>
    /// List all forwards for the specified domain.
    /// </summary>
    /// <param name="domainId">ID of the domain</param>
    /// <param name="cancellationToken"></param>
    [Get($"/domains/{{{nameof(domainId)}}}/forwards/")]
    Task<IReadOnlyList<HttpForwardModel>> ListForwardsAsync(int domainId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a forwarding for the specified domain, to a given URL.<br/>
    /// <br/>
    /// The forward must not collide with any existing forwarding or DNS record<br/>
    /// of types `A`, `AAAA`, `ANAME` or `CNAME`.
    /// </summary>
    /// <param name="domainId">ID of the domain</param>
    /// <param name="forward"></param>
    /// <param name="cancellationToken"></param>
    [Post($"/domains/{{{nameof(domainId)}}}/forwards/")]
    Task AddForwardAsync(int domainId, HttpForwardModel forward, CancellationToken cancellationToken = default);

    /// <summary>
    /// Find forward by host
    /// </summary>
    /// <param name="domainId">ID of the domain</param>
    /// <param name="host">Subdomain of the forward, @ for the root domain</param>
    /// <param name="cancellationToken"></param>
    [Get($"/domains/{{{nameof(domainId)}}}/forwards/{{{nameof(host)}}}")]
    Task<HttpForwardModel> FindForwardByHostAsync(int domainId, string host, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a forwarding for the specified domain, to a given URL.<br/>
    /// <br/>
    /// The `host` field must not be changed. In that case, delete the<br/>
    /// existing forwarding and recreate it for the new host/subdomain.
    /// </summary>
    /// <param name="domainId">ID of the domain</param>
    /// <param name="host">Subdomain of the forward, @ for the root domain</param>
    /// <param name="forward"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Put($"/domains/{{{nameof(domainId)}}}/forwards/{{{nameof(host)}}}")]
    Task<HttpForwardModel> UpdateForwardByHostAsync(int domainId, string host, HttpForwardModel forward, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete forward by host
    /// </summary>
    /// <param name="domainId">ID of the domain</param>
    /// <param name="host">Subdomain of the forward, @ for the root domain</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Delete($"/domains/{{{nameof(domainId)}}}/forwards/{{{nameof(host)}}}")]
    Task DeleteForwardByHostAsync(int domainId, string host, CancellationToken cancellationToken = default);

}
