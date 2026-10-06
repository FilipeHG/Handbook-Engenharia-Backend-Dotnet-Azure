# 03 — Convenções em Português do Brasil

## Regra corporativa

Projetos, pastas, arquivos, classes, métodos, propriedades de domínio e documentação devem usar **Português do Brasil**.

### Exemplos

```text
Controllers/SolicitacoesController.cs
Aplicacao/Solicitacoes/CriarSolicitacao/CriarSolicitacaoServico.cs
Dominio/Solicitacoes/Solicitacao.cs
Infraestrutura/Persistencia/Repositorios/RepositorioSolicitacoes.cs
```

```csharp
public sealed class Solicitacao
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; } = string.Empty;

    public void Concluir(DateTimeOffset agora)
    {
        if (Status == StatusSolicitacao.Concluida)
            throw new RegraDeNegocioException("A solicitação já está concluída.");

        Status = StatusSolicitacao.Concluida;
        ConcluidaEm = agora;
    }
}
```

## Exceções legítimas

Não traduzir nomes oficiais de:

- classes/frameworks (`DbContext`, `HttpClient`, `ServiceClient`);
- protocolos (`OAuth`, `OpenAPI`, `HTTP`);
- propriedades exigidas por SDK/serialização externa;
- tabelas/atributos existentes do Dataverse quando o logical name é imposto pelo sistema externo.

## Padrões C#

- PascalCase: tipos, métodos, propriedades.
- camelCase: parâmetros e variáveis locais.
- `_camelCase`: campos privados.
- interfaces: `I` + substantivo em PT-BR (`IRepositorioSolicitacoes`).
- métodos devem expressar intenção: `ObterPorIdAsync`, `RegistrarAsync`, `PodeSerCancelada`.
