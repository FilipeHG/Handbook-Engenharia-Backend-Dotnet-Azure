using System.Data;
using Dapper;
using Empresa.Modelo.Aplicacao.Abstracoes;
using Empresa.Modelo.Dominio.Solicitacoes;

namespace Empresa.Modelo.Infraestrutura.Persistencia.Dapper;

public sealed class RepositorioSolicitacoesDapper(Func<IDbConnection> fabricaConexao) : IRepositorioSolicitacoes
{
    public async Task AdicionarAsync(Solicitacao solicitacao, CancellationToken cancellationToken)
    {
        const string sql = """
            INSERT INTO Solicitacoes (Id, Titulo, CriadaEm)
            VALUES (@Id, @Titulo, @CriadaEm);
            """;

        using var conexao = fabricaConexao();
        var comando = new CommandDefinition(sql, solicitacao, cancellationToken: cancellationToken);
        await conexao.ExecuteAsync(comando);
    }

    public async Task<Solicitacao?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT Id, Titulo, CriadaEm
            FROM Solicitacoes
            WHERE Id = @Id;
            """;

        using var conexao = fabricaConexao();
        var comando = new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken);
        return await conexao.QuerySingleOrDefaultAsync<Solicitacao>(comando);
    }
}
