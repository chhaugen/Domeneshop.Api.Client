using Chhaugen.Domeneshop.Api.Client.Models;
using Refit;

namespace Chhaugen.Domeneshop.Api.Client;

/// <summary>
/// List invoices for your account. Only invoices from the past 3 years are returned.
/// </summary>
public interface IInvoicesEndpoints
{

    [Get("/invoices")]
    Task<IReadOnlyList<InvoiceModel>> ListInvoices(InvoiceStatusEnum? status = null, CancellationToken cancellationToken = default);

    [Get($"/invoices/{{{nameof(invoiceId)}}}")]
    Task<InvoiceModel> FindInvoiceByInvoiceNumberAsync(int invoiceId, CancellationToken cancellationToken = default);
}
