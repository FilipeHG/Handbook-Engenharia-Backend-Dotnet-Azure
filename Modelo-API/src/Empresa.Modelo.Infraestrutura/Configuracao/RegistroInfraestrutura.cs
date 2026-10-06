using Azure.Core;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Empresa.Modelo.Infraestrutura.Configuracao;

public static class RegistroInfraestrutura
{
    public static IServiceCollection AdicionarInfraestrutura(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment ambiente)
    {
        TokenCredential credencialAzure = ambiente.IsDevelopment()
            ? new DefaultAzureCredential()
            : CriarCredencialGerenciada(configuration);

        // Registrar aqui TableClient, SecretClient, ServiceBusClient,
        // implementações de repositório e cliente Dataverse.
        // O host escolhe EF ou Dapper via registro explícito.

        return services;
    }

    private static TokenCredential CriarCredencialGerenciada(IConfiguration configuration)
    {
        var clientId = configuration["Azure:ManagedIdentityClientId"];

        return string.IsNullOrWhiteSpace(clientId)
            ? new ManagedIdentityCredential()
            : new ManagedIdentityCredential(ManagedIdentityId.FromUserAssignedClientId(clientId));
    }
}
