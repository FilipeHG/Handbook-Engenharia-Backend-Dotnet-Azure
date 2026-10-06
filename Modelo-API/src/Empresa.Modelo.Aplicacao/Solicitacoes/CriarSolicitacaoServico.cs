using Empresa.Modelo.Aplicacao.Abstracoes;
using Empresa.Modelo.Dominio.Solicitacoes;

namespace Empresa.Modelo.Aplicacao.Solicitacoes;

public sealed class CriarSolicitacaoServico(IRepositorioSolicitacoes repositorio, TimeProvider timeProvider)
{
    public async Task<Guid> ExecutarAsync(string titulo, CancellationToken cancellationToken)
    {
        var solicitacao = Solicitacao.Criar(titulo, timeProvider.GetUtcNow());
        await repositorio.AdicionarAsync(solicitacao, cancellationToken);
        return solicitacao.Id;
    }
}
