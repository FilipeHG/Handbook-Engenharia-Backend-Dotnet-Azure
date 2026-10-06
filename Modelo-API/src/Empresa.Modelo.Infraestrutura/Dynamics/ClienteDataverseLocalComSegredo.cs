using Microsoft.PowerPlatform.Dataverse.Client;

namespace Empresa.Modelo.Infraestrutura.Dynamics;

public static class ClienteDataverseLocalComSegredo
{
    public static ServiceClient Criar(Uri url, string clientId, string clientSecret)
        => new(url, clientId, clientSecret, useUniqueInstance: false);
}
