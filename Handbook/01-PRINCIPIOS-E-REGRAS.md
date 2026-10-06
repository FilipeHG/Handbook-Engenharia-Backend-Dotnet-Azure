# 01 — Princípios e Regras

## Princípios obrigatórios

- **Clareza sobre esperteza:** código deve ser simples de ler, depurar e operar.
- **KISS e YAGNI:** não introduzir abstrações sem necessidade concreta.
- **SOLID com pragmatismo:** aplicar principalmente SRP, DIP e ISP onde existem boundaries reais.
- **Dependency Rule:** dependências apontam para dentro.
- **Security by default:** acesso mínimo, segredo fora do código e autenticação moderna.
- **Observability by design:** logs, métricas, traces e correlação nascem com a feature.
- **Testabilidade:** regras de negócio não dependem de infraestrutura.
- **Automação:** tudo que puder ser verificado no pipeline deve sair da memória humana.

## Regras de ouro

### OBRIGATÓRIO

- `CancellationToken` em operações de I/O e métodos async públicos de Application/Infrastructure.
- `async/await` end-to-end para I/O.
- UTC internamente (`DateTimeOffset` preferencialmente para instantes).
- SQL parametrizado.
- DTO HTTP separado de entidade de domínio e schema de banco.
- Segredos nunca versionados.
- Logs estruturados; nunca concatenar dados sensíveis em mensagens.
- PR obrigatório para branch protegida.

### PROIBIDO em novo desenvolvimento

- Usuário/senha para integração server-to-server com Dataverse.
- Controller com regra de negócio ou acesso direto a repositório/DbContext/ServiceClient.
- `catch (Exception) { return 400; }`.
- `IRepository<T>` genérico como abstração universal.
- Service Locator.
- Singleton com estado mutável de request.
- `Task.Result`, `.Wait()` e sync-over-async.
- secrets em `appsettings*.json`, README, scripts ou testes.
- log de token JWT, Authorization header, client secret ou dados pessoais sem mascaramento.

## Quando abstrair

Crie interface quando existir boundary, substituição relevante, integração externa, isolamento para testes ou mais de uma estratégia real. Não crie interface apenas porque há uma classe.
