using Empresa.Modelo.Dominio.Solicitacoes;
using Xunit;

namespace Empresa.Modelo.Testes.Unitarios;

public sealed class SolicitacaoTestes
{
    [Fact]
    public void Criar_DeveFalhar_QuandoTituloVazio()
    {
        Assert.Throws<ArgumentException>(() => Solicitacao.Criar(" ", DateTimeOffset.UtcNow));
    }
}
