using Chhaugen.Domeneshop.Api.Client.Models;
using Refit;

namespace Chhaugen.Domeneshop.Api.Client;

/// <summary>
/// Domains
/// </summary>
public interface IDomainsEndpoints
{
    /// <summary>
    /// List domains
    /// </summary>
    /// <param name="domain" example=".no">Only return domains whose `domain` field includes this string</param>
    /// <param name="cancellationToken"></param>
    [Get("/domains")]
    Task<IReadOnlyList<DomainModel>> ListDomainsAsync(string? domain = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Find domain by ID
    /// </summary>
    [Get($"/domains/{{{nameof(domainId)}}}")]
    Task<DomainModel> FindDomainByIdAsync(int domainId, CancellationToken cancellationToken = default);
}
