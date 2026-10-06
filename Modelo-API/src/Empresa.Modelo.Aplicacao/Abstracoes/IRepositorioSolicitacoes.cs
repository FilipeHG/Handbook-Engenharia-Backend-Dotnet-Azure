using Empresa.Modelo.Dominio.Solicitacoes;

namespace Empresa.Modelo.Aplicacao.Abstracoes;

public interface IRepositorioSolicitacoes
{
    Task<Solicitacao?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
    Task AdicionarAsync(Solicitacao solicitacao, CancellationToken cancellationToken);
}
