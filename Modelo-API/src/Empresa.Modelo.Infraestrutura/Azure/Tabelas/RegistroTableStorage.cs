using Azure.Core;
using Azure.Data.Tables;
using Azure.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Empresa.Modelo.Infraestrutura.Azure.Tabelas;

public static class RegistroTableStorage
{
    public static IServiceCollection AdicionarTabela(
        this IServiceCollection services,
        Uri endpoint,
        string nomeTabela,
        bool ambienteAzure,
        string? clientIdIdentidadeGerenciada = null)
    {
        TokenCredential credencial = ambienteAzure
            ? string.IsNullOrWhiteSpace(clientIdIdentidadeGerenciada)
                ? new ManagedIdentityCredential()
                : new ManagedIdentityCredential(ManagedIdentityId.FromUserAssignedClientId(clientIdIdentidadeGerenciada))
            : new DefaultAzureCredential();

        services.AddSingleton(new TableClient(endpoint, nomeTabela, credencial));
        services.AddSingleton<RepositorioTabelaAuditoria>();
        return services;
    }
}
