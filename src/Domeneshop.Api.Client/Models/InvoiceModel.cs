using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client.Models;

/// <summary>
/// Invoice
/// </summary>
/// <param name="Id">Invoice ID/number</param>
/// <param name="Type"></param>
/// <param name="Amount"></param>
/// <param name="Currency"></param>
/// <param name="DueDate">The invoice due date. Only available for type `invoice`.</param>
/// <param name="IssuedDate">The date when the invoice was issued.</param>
/// <param name="PaidDate">The payment date. Only available if the invoice has status `paid`.</param>
/// <param name="Status">`settled` is only applicable to credit notes. These are usually created if domains have been</param>
/// <param name="Url"></param>
public record InvoiceModel(
    [property: JsonPropertyName("id")]
    int Id = default,

    [property: JsonPropertyName("type")]
    InvoiceTypeEnum Type = default,

    [property: JsonPropertyName("amount")]
    int Amount = default,

    [property: JsonPropertyName("currency")]
    InvoiceCurrencyEnum Currency = default,

    [property: JsonPropertyName("due_date")]
    DateOnly? DueDate = null,

    [property: JsonPropertyName("issued_date")]
    DateOnly? IssuedDate = null,

    [property: JsonPropertyName("paid_date")]
    DateOnly? PaidDate = null,

    [property: JsonPropertyName("status")]
    InvoiceStatusEnum Status = default,

    [property: JsonPropertyName("url")]
    [StringSyntax(StringSyntaxAttribute.Uri)]
    string? Url = null
    );
