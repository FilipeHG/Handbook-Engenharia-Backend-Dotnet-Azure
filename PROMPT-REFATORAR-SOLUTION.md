Você é um Engenheiro de Software Sênior e Arquiteto .NET responsável por modernizar esta solution existente.

A fonte normativa obrigatória para todas as decisões é a pasta:

`Handbook-Engenharia-Backend-DotNet10-Azure`

Antes de alterar qualquer arquivo, leia obrigatoriamente:

- `Handbook-Engenharia-Backend-DotNet10-Azure/AGENTS.md`
- `Handbook-Engenharia-Backend-DotNet10-Azure/README.md`
- `Handbook-Engenharia-Backend-DotNet10-Azure/INDICE.md`

Depois leia todos os documentos do Handbook que tenham relação com:

- arquitetura;
- Clean Architecture;
- SOLID;
- Dependency Injection;
- API REST;
- OpenAPI;
- tratamento de erros;
- validações;
- segurança;
- autenticação e autorização;
- Azure;
- Managed Identity;
- Key Vault;
- configuração;
- Dynamics 365 / Dataverse;
- Entity Framework Core;
- Dapper;
- banco de dados;
- Azure Functions;
- Workers;
- testes unitários;
- testes de integração;
- testes E2E;
- observabilidade;
- resiliência;
- logging;
- health checks;
- pipelines;
- Git Flow;
- Code Review;
- modernização de aplicações legadas;
- production readiness.

## OBJETIVO

Analise a solution atual inteira e refatore-a para que fique aderente ao padrão arquitetural e às normas definidas no `Handbook-Engenharia-Backend-DotNet10-Azure`.

A solution existente pode possuir:

- projetos fora da arquitetura proposta;
- controllers com regra de negócio;
- services acoplados;
- acesso direto ao banco;
- repositories mal definidos;
- Entity Framework ou Dapper utilizados incorretamente;
- Azure Functions fora do padrão;
- Workers fora do padrão;
- integrações com Dynamics acopladas;
- autenticação inadequada;
- secrets em arquivos;
- configurações espalhadas;
- testes insuficientes;
- testes fora da estrutura recomendada;
- ausência de testes E2E;
- ausência de observabilidade;
- dependências entre projetos incompatíveis com Clean Architecture;
- nomenclaturas diferentes do padrão corporativo;
- código legado;
- bibliotecas obsoletas;
- configurações inadequadas para Azure.

Todo o código, nomes de projetos, diretórios, classes, arquivos, métodos, DTOs, interfaces, variáveis de negócio e documentação criada devem utilizar **Português do Brasil**, conforme definido no Handbook.

Termos técnicos consolidados que fazem parte de frameworks ou padrões podem permanecer em inglês quando necessário, por exemplo:

- Controller
- Middleware
- Repository
- Worker
- HealthCheck
- OpenAPI
- Entity Framework
- Dapper

Não traduza nomes de APIs ou tipos do .NET.

---

# FASE 1 — INVENTÁRIO COMPLETO

Antes de realizar qualquer alteração, analise toda a solution.

Mapeie:

1. Projetos existentes.
2. Dependências entre projetos.
3. Target Framework de cada projeto.
4. Pacotes NuGet.
5. Controllers e endpoints.
6. Services.
7. Repositories.
8. Entidades.
9. DTOs.
10. Validators.
11. Middlewares.
12. Filters.
13. Hosted Services.
14. Workers.
15. Azure Functions.
16. Integrações com Dynamics/Dataverse.
17. Integrações Azure.
18. Banco de dados.
19. Entity Framework Core.
20. Dapper.
21. Storage.
22. Azure Table Storage.
23. autenticação.
24. autorização.
25. configuração.
26. secrets.
27. appsettings.
28. variáveis de ambiente.
29. arquivos `.env`.
30. Key Vault.
31. logging.
32. observabilidade.
33. tratamento de erros.
34. health checks.
35. testes unitários.
36. testes de integração.
37. testes E2E.
38. pipelines.
39. Dockerfiles.
40. scripts.
41. documentação.

Não faça alterações durante esta fase.

---

# FASE 2 — GAP ANALYSIS

Compare a implementação atual com o Handbook.

Crie um relatório chamado:

`docs/modernizacao/01-DIAGNOSTICO-ARQUITETURAL.md`

Para cada problema encontrado, informe:

- situação atual;
- regra correspondente do Handbook;
- problema arquitetural;
- risco técnico;
- severidade;
- recomendação;
- impacto esperado da alteração.

Classifique cada item como:

- CRÍTICO
- ALTO
- MÉDIO
- BAIXO

Identifique especialmente:

- dependências invertidas incorretamente;
- Domain dependendo de Infrastructure;
- Application dependendo de Infrastructure;
- controllers acessando banco;
- controllers contendo regra de negócio;
- regras de negócio em Infrastructure;
- DTOs acoplados ao banco;
- EF Core vazando para Application ou Domain;
- Dapper vazando para Application ou Domain;
- integrações Dynamics dentro de controllers;
- secrets versionados;
- connection strings hardcoded;
- ausência de Managed Identity;
- ausência de abstrações de integração;
- Functions com domínio duplicado;
- Workers duplicando regra de negócio;
- código sem CancellationToken;
- SQL concatenado;
- logging não estruturado;
- ausência de correlation ID;
- ausência de Problem Details;
- ausência de validação;
- testes acoplados;
- testes sem isolamento;
- ausência de E2E;
- ausência de testes das Functions;
- ausência de testes dos Workers.

---

# FASE 3 — ARQUITETURA DE DESTINO

Crie:

`docs/modernizacao/02-ARQUITETURA-DESTINO.md`

Defina a arquitetura final da solution antes de mover código.

Use como referência o modelo estabelecido no Handbook.

Preferencialmente organize a solution em algo equivalente a:

```text
src/
├── NomeDoSistema.Api/
├── NomeDoSistema.Aplicacao/
├── NomeDoSistema.Dominio/
├── NomeDoSistema.Infraestrutura/
├── NomeDoSistema.Functions/
└── NomeDoSistema.Worker/

tests/
├── NomeDoSistema.Dominio.Testes/
├── NomeDoSistema.Aplicacao.Testes/
├── NomeDoSistema.Infraestrutura.Testes/
├── NomeDoSistema.Api.Testes.Integracao/
├── NomeDoSistema.Api.Testes.E2E/
├── NomeDoSistema.Functions.Testes/
└── NomeDoSistema.Worker.Testes/
```

Não crie projetos desnecessários apenas para seguir um desenho visual.

Aplique o princípio:

> A menor arquitetura que preserve corretamente os boundaries.

Documente também o grafo permitido de dependências.

---

# FASE 4 — PLANO DE MIGRAÇÃO

Crie:

`docs/modernizacao/03-PLANO-DE-MIGRACAO.md`

Divida a modernização em etapas pequenas e seguras.

Exemplo:

1. atualizar solution e projetos;
2. reorganizar dependências;
3. criar Domain;
4. criar Application;
5. mover regras de negócio;
6. estruturar Infrastructure;
7. reorganizar persistência;
8. reorganizar Dynamics;
9. reorganizar Functions;
10. reorganizar Workers;
11. implementar configuração;
12. implementar Managed Identity;
13. implementar Key Vault;
14. padronizar REST/OpenAPI;
15. padronizar erros;
16. padronizar observabilidade;
17. criar health checks;
18. reorganizar testes;
19. criar testes E2E;
20. revisar dependências;
21. remover código morto;
22. validar build;
23. validar testes;
24. validar segurança;
25. atualizar documentação.

Cada etapa deve informar:

- objetivo;
- arquivos afetados;
- risco;
- estratégia de rollback;
- validação esperada.

---

# FASE 5 — EXECUÇÃO

Após produzir o diagnóstico, arquitetura e plano, inicie a refatoração.

Faça mudanças incrementalmente.

Após cada grupo significativo de alterações:

1. execute restore;
2. compile a solution;
3. execute testes relevantes;
4. corrija erros antes de continuar.

Nunca acumule dezenas de alterações quebradas.

---

# REGRAS ARQUITETURAIS OBRIGATÓRIAS

A solução final deve respeitar:

```text
API
  ↓
Aplicacao
  ↓
Dominio

Infraestrutura
  ↓
Aplicacao
  ↓
Dominio
```

A API pode conhecer Infrastructure apenas no Composition Root.

Domain:

- não conhece banco;
- não conhece Azure;
- não conhece HTTP;
- não conhece Dynamics;
- não conhece EF Core;
- não conhece Dapper;
- não conhece SDKs externos.

Application:

- coordena casos de uso;
- define ports/interfaces necessárias;
- depende de Domain;
- não conhece implementações de Infrastructure.

Infrastructure:

- implementa ports;
- banco;
- Dynamics;
- Azure;
- Storage;
- Key Vault;
- mensageria;
- integrações externas.

API:

- transporte HTTP;
- autenticação;
- autorização;
- contratos;
- composição da aplicação.

Functions e Workers:

- são hosts;
- não devem duplicar regras;
- reutilizam Application e Domain;
- possuem Composition Root próprio.

---

# PERSISTÊNCIA

Analise se o projeto deve continuar utilizando:

- Entity Framework Core;
- Dapper;
- ou uma combinação consciente de ambos.

Não troque EF Core por Dapper ou Dapper por EF Core sem justificativa.

Use os critérios do Handbook.

Se utilizar EF Core:

- mantenha `DbContext` em Infrastructure;
- não exponha EF para Domain/Application;
- configure migrations adequadamente;
- utilize tracking apenas quando necessário;
- evite N+1;
- utilize projeções;
- implemente concorrência quando aplicável.

Se utilizar Dapper:

- SQL parametrizado obrigatoriamente;
- connections gerenciadas;
- SQL localizado em Infrastructure;
- CancellationToken;
- transações explícitas quando necessárias;
- nenhum SQL dentro de controllers/services de Application.

---

# DYNAMICS / DATAVERSE

Toda integração com Dynamics deve ficar atrás de um port da Application.

Não permita:

```text
Controller -> ServiceClient
Function -> ServiceClient
Worker -> ServiceClient
```

Prefira:

```text
Controller
    ↓
CasoDeUso
    ↓
IPortDynamics
    ↓
AdaptadorDataverse
```

Para Azure:

- utilizar Managed Identity preferencialmente;
- evitar usuário/senha;
- evitar client secret em produção quando Managed Identity for possível;
- usar Application User do Dataverse;
- aplicar menor privilégio.

Para desenvolvimento local:

- permitir credencial de desenvolvedor;
- ou Client Secret quando necessário;
- nunca versionar secrets.

---

# AZURE FUNCTIONS

Refatore Functions para atuarem como adaptadores/hosts.

Functions devem ser pequenas.

Exemplo:

```text
Trigger
  ↓
Function
  ↓
Application Use Case
  ↓
Domain
  ↓
Ports
  ↓
Infrastructure
```

Nunca copie regras de negócio da API para Functions.

Garanta testes para:

- trigger;
- binding;
- caso de uso chamado;
- erros;
- integração externa quando aplicável.

---

# WORKERS

Workers devem orquestrar processamento assíncrono.

Não devem conter regra de negócio principal.

Utilize:

- `BackgroundService` quando adequado;
- CancellationToken;
- logging estruturado;
- tratamento de shutdown;
- retries controlados;
- idempotência quando necessária;
- poison message/DLQ quando aplicável.

---

# CONFIGURAÇÃO E SEGREDOS

Padronize:

```text
appsettings.json
appsettings.Development.json
Environment Variables
User Secrets
.env somente quando permitido pelo padrão
Azure Key Vault
Managed Identity
```

Nenhum secret pode ficar versionado.

Procure ativamente por:

- passwords;
- connection strings;
- client secrets;
- tokens;
- API keys;
- SAS tokens;
- certificados;
- credenciais Dynamics.

Caso sejam encontrados, remova-os da configuração versionada e documente a migração.

---

# OBSERVABILIDADE

Implemente o baseline definido no Handbook:

- structured logging;
- correlation ID;
- OpenTelemetry;
- traces;
- metrics;
- logs;
- Application Insights quando aplicável;
- health checks;
- readiness;
- liveness.

Nunca registre:

- tokens;
- passwords;
- secrets;
- dados pessoais desnecessários.

---

# API REST

Padronize:

- rotas;
- controllers;
- códigos HTTP;
- contratos;
- DTOs;
- versionamento quando necessário;
- Problem Details;
- OpenAPI;
- validação.

Controllers devem ser finos.

Não devem conter lógica de negócio.

---

# TESTES

Estruture testes conforme o Handbook.

Obrigatoriamente considere:

## Testes unitários

Domain e Application.

## Testes de integração

Infrastructure, banco e adapters.

## Testes E2E

Fluxos completos HTTP.

## Functions

Testes de Functions e seus adapters.

## Workers

Testes dos ciclos e casos de uso chamados pelo Worker.

Não escreva testes apenas para aumentar coverage.

Teste comportamento e regras relevantes.

---

# MODERNIZAÇÃO DE LEGADO

Não faça rewrite completo sem necessidade.

Utilize modernização incremental.

Preserve comportamento público existente sempre que possível.

Antes de modificar comportamento:

1. identifique contrato atual;
2. crie characterization tests quando necessário;
3. documente breaking change;
4. somente então altere comportamento.

---

# NOMENCLATURA

Todo código corporativo deve seguir Português do Brasil.

Exemplo:

```text
SolicitacaoController
CriarSolicitacao
ISolicitacaoRepositorio
SolicitacaoRepositorio
IntegracaoDynamics
ClienteDynamics
ProcessadorDePedidoWorker
SincronizarClienteFunction
```

Evite misturar:

```text
CustomerService
SolicitacaoRepository
PedidoHandler
```

na mesma solução.

---

# DEPENDÊNCIAS

Não adicione bibliotecas automaticamente.

Para toda nova dependência:

- informe por que é necessária;
- verifique se o .NET oferece recurso nativo;
- evite dependências redundantes;
- utilize versões compatíveis com .NET 10;
- não introduza frameworks arquiteturais sem necessidade.

Não introduza automaticamente:

- MediatR;
- AutoMapper;
- FluentResults;
- generic repository;
- CQRS framework;
- event bus;
- mass transit;
- abstrações adicionais;

a menos que exista justificativa arquitetural concreta e aderência ao Handbook.

---

# DOCUMENTAÇÃO FINAL

Ao finalizar, gere:

```text
docs/modernizacao/
├── 01-DIAGNOSTICO-ARQUITETURAL.md
├── 02-ARQUITETURA-DESTINO.md
├── 03-PLANO-DE-MIGRACAO.md
├── 04-ALTERACOES-REALIZADAS.md
├── 05-DECISOES-ARQUITETURAIS.md
└── 06-PENDENCIAS-E-RISCOS.md
```

Em `04-ALTERACOES-REALIZADAS.md`, explique:

- o que existia;
- o que foi alterado;
- por quê;
- quais regras do Handbook foram aplicadas.

---

# CRITÉRIOS DE CONCLUSÃO

Não considere a tarefa concluída até que:

- a solution compile;
- todos os projetos estejam em .NET 10 quando tecnicamente possível;
- dependências estejam corretas;
- arquitetura respeite o Handbook;
- secrets não estejam versionados;
- banco esteja abstraído;
- Dynamics esteja abstraído;
- Managed Identity esteja preparado;
- Functions estejam padronizadas;
- Workers estejam padronizados;
- testes unitários estejam passando;
- testes de integração estejam passando;
- testes E2E estejam passando;
- testes de Functions estejam passando;
- testes de Workers estejam passando;
- OpenAPI esteja válido;
- health checks estejam funcionando;
- observabilidade esteja configurada;
- documentação esteja atualizada;
- código morto introduzido pela migração seja removido.

Se algum item não puder ser concluído, registre explicitamente em:

`docs/modernizacao/06-PENDENCIAS-E-RISCOS.md`

Nunca declare sucesso silenciosamente quando ainda existir problema.

## REGRA FINAL

O `Handbook-Engenharia-Backend-DotNet10-Azure` é a fonte de verdade.

Quando houver conflito entre:

- código legado;
- convenção atual do projeto;
- preferência pessoal;
- sugestão automática da IDE;

e o Handbook,

**o Handbook prevalece**, exceto quando isso causar quebra funcional comprovada. Nesse caso, documente o conflito e proponha uma estratégia incremental de migração.