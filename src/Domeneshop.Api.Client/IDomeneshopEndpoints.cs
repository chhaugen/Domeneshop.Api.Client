namespace Chhaugen.Domeneshop.Api.Client;

public interface IDomeneshopEndpoints :
    IDomainsEndpoints,
    IDnsEndpoints,
    IDdnsEndpoints,
    IHttpForwardsEndpoints,
    IInvoicesEndpoints
{
}
