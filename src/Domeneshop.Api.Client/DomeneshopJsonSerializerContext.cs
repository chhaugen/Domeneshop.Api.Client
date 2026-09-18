using Chhaugen.Domeneshop.Api.Client.Models;
using System.Text.Json.Serialization;

namespace Chhaugen.Domeneshop.Api.Client;

[JsonSerializable(typeof(AddDnsRecordResponseModel))]
[JsonSerializable(typeof(DomainModel))]
[JsonSerializable(typeof(IReadOnlyList<DomainModel>))]
[JsonSerializable(typeof(DomainServicesModel))]
[JsonSerializable(typeof(HttpForwardModel))]
[JsonSerializable(typeof(IReadOnlyList<HttpForwardModel>))]
[JsonSerializable(typeof(InvoiceCurrencyEnum))]
[JsonSerializable(typeof(InvoiceModel))]
[JsonSerializable(typeof(IReadOnlyList<InvoiceModel>))]
[JsonSerializable(typeof(InvoiceStatusEnum))]
[JsonSerializable(typeof(InvoiceTypeEnum))]
[JsonSerializable(typeof(RecordModel))]
[JsonSerializable(typeof(IReadOnlyList<RecordModel>))]
[JsonSerializable(typeof(RecordTypeEnum))]
[JsonSerializable(typeof(StatusEnum))]
[JsonSerializable(typeof(WebhotelEnum))]
public partial class DomeneshopJsonSerializerContext : JsonSerializerContext
{ }
