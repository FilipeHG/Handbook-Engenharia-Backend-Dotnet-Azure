# 05 — Domínio, Aplicação e Dependency Injection

## Domínio

Deve ser framework-agnostic. Não referencia ASP.NET Core, Azure SDK, EF Core, Dapper ou Dataverse SDK.

## Aplicação

Casos de uso devem ser pequenos e explícitos. Exemplo:

```csharp
public sealed class CriarSolicitacaoServico(
    IRepositorioSolicitacoes repositorio,
    IRelogio relogio)
{
    public async Task<Guid> ExecutarAsync(
        CriarSolicitacaoComando comando,
        CancellationToken cancellationToken)
    {
        var solicitacao = Solicitacao.Criar(comando.Titulo, relogio.Agora);
        await repositorio.AdicionarAsync(solicitacao, cancellationToken);
        return solicitacao.Id;
    }
}
```

## Ports

Interfaces pertencem à camada que **necessita** da capacidade:

```csharp
public interface IRepositorioSolicitacoes
{
    Task<Solicitacao?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken);
    Task AdicionarAsync(Solicitacao solicitacao, CancellationToken cancellationToken);
}
```

Infrastructure implementa o port.

## Lifetimes

- `Singleton`: stateless, thread-safe, configuração/cache controlado.
- `Scoped`: DbContext, unidade lógica por request quando necessário.
- `Transient`: serviços leves e stateless.

Nunca capturar serviço Scoped dentro de Singleton.
