using Azure;
using Azure.Data.Tables;

namespace Empresa.Modelo.Infraestrutura.Azure.Tabelas;

public sealed class RepositorioTabelaAuditoria(TableClient tabela)
{
    public async Task RegistrarAsync(string particao, string id, string evento, CancellationToken cancellationToken)
    {
        var entidade = new TableEntity(particao, id)
        {
            ["Evento"] = evento,
            ["RegistradoEm"] = DateTimeOffset.UtcNow
        };

        await tabela.UpsertEntityAsync(entidade, TableUpdateMode.Replace, cancellationToken);
    }
}
