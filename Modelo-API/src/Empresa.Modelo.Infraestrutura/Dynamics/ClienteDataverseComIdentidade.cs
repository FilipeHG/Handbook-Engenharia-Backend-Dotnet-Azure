using Azure.Core;
using Azure.Identity;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace Empresa.Modelo.Infraestrutura.Dynamics;

public sealed class ClienteDataverseComIdentidade : IDisposable
{
    private readonly ServiceClient _cliente;

    public ClienteDataverseComIdentidade(Uri urlDataverse, string? clientIdIdentidadeGerenciada = null)
    {
        TokenCredential credencial = string.IsNullOrWhiteSpace(clientIdIdentidadeGerenciada)
            ? new ManagedIdentityCredential()
            : new ManagedIdentityCredential(ManagedIdentityId.FromUserAssignedClientId(clientIdIdentidadeGerenciada));

        async Task<string> ObterTokenAsync(string _)
        {
            var autoridade = urlDataverse.GetLeftPart(UriPartial.Authority);
            var contexto = new TokenRequestContext([$"{autoridade}/.default"]);
            var token = await credencial.GetTokenAsync(contexto, CancellationToken.None);
            return token.Token;
        }

        _cliente = new ServiceClient(urlDataverse, ObterTokenAsync, useUniqueInstance: false);
    }

    public ServiceClient Cliente => _cliente;
    public void Dispose() => _cliente.Dispose();
}
