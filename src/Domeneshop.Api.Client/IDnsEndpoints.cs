using Chhaugen.Domeneshop.Api.Client.Models;
using Refit;

namespace Chhaugen.Domeneshop.Api.Client;

/// <summary>
/// These endpoints allow you to list, create and delete DNS records for any domain that has
/// active DNS service.
/// </summary>
public interface IDnsEndpoints
{
    /// <summary>
    /// List DNS records
    /// </summary>
    /// <param name="domainId"></param>
    /// <param name="host" example="www">Only return records whose `host` field matches this string</param>
    /// <param name="type" example="A">Only return records whose `type` field matches this string</param>
    /// <param name="cancellationToken"></param>
    [Get($"/domains/{{{nameof(domainId)}}}/dns")]
    Task<IReadOnlyList<RecordModel>> ListDnsRecordsAsync(int domainId, string? host = null, RecordTypeEnum? type = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Find DNS record by ID
    /// </summary>
    [Post($"/domains/{{{nameof(domainId)}}}/dns")]
    Task<AddDnsRecordResponseModel> AddDnsRecordAsync(int domainId, RecordModel record, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update DNS record by ID
    /// </summary>
    [Get($"/domains/{{{nameof(domainId)}}}/dns/{{{nameof(recordId)}}}")]
    Task<RecordModel> FindDnsRecordByIdAsync(int domainId, int recordId, CancellationToken cancellationToken = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="domainId"></param>
    /// <param name="recordId"></param>
    /// <param name="record"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Put($"/domains/{{{nameof(domainId)}}}/dns/{{{nameof(recordId)}}}")]
    Task UpdateDnsRecordByIdAsync(int domainId, int recordId, RecordModel record, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete DNS record by ID
    /// </summary>
    [Delete($"/domains/{{{nameof(domainId)}}}/dns/{{{nameof(recordId)}}}")]
    Task DeleteDnsRecordByIdAsync(int domainId, int recordId, CancellationToken cancellationToken = default);
}
