# PROMPT — CRIAR NOVA API .NET 10 CONFORME O HANDBOOK

Você é um Engenheiro de Software Sênior e Arquiteto .NET responsável por criar uma nova API corporativa do zero.

A fonte normativa obrigatória para todas as decisões é a pasta:

`Handbook-Engenharia-Backend-DotNet10-Azure`

Antes de criar qualquer arquivo ou projeto, leia obrigatoriamente:

- `AGENTS.md`
- `README.md`
- `INDICE.md`
- todos os documentos relevantes da pasta `Handbook`
- todos os documentos relevantes da pasta `Fontes`
- o conteúdo da pasta `Modelo-API`
- as orientações da pasta `IA`

A documentação acima é a fonte de verdade arquitetural, técnica e de segurança.

Quando houver conflito entre uma sugestão automática da IDE, uma preferência pessoal, uma biblioteca externa ou uma convenção genérica e o Handbook, o Handbook prevalece.

---

# OBJETIVO

Criar uma nova API Backend corporativa utilizando:

- .NET 10;
- ASP.NET Core;
- arquitetura definida no Handbook;
- Azure de ponta a ponta quando aplicável;
- integração com Dynamics 365 / Dataverse quando necessária;
- banco de dados relacional;
- Entity Framework Core ou Dapper, conforme decisão técnica;
- Azure Functions quando necessárias;
- Worker Services quando necessários;
- Azure Table Storage quando necessário;
- Managed Identity;
- Azure Key Vault;
- autenticação e autorização conforme o contexto;
- OpenAPI;
- testes unitários;
- testes de integração;
- testes E2E;
- observabilidade;
- health checks;
- práticas seguras de configuração;
- CI/CD preparado;
- código e nomenclatura em Português do Brasil.

A solução deve nascer aderente ao Handbook, evitando retrabalho arquitetural posterior.

---

# REGRA PRINCIPAL

Não comece criando projetos imediatamente.

Primeiro entenda o contexto solicitado e produza uma proposta mínima de arquitetura.

Aplique sempre:

> A menor arquitetura capaz de preservar corretamente os boundaries, segurança, testabilidade, manutenção e evolução do sistema.

Não introduza abstrações, frameworks ou projetos sem justificativa.

---

# FASE 1 — ENTENDIMENTO DO CONTEXTO

Antes de criar código, identifique a partir da solicitação disponível:

1. nome do sistema;
2. objetivo da API;
3. domínio principal;
4. principais recursos REST;
5. controllers previstas;
6. casos de uso;
7. entidades de domínio;
8. integrações externas;
9. necessidade de Dynamics / Dataverse;
10. necessidade de Azure Functions;
11. necessidade de Worker;
12. necessidade de banco relacional;
13. banco relacional escolhido, quando informado;
14. necessidade de Entity Framework Core;
15. necessidade de Dapper;
16. necessidade de Azure Table Storage;
17. necessidade de mensageria;
18. autenticação;
19. autorização;
20. ambientes previstos;
21. requisitos não funcionais;
22. requisitos de segurança;
23. requisitos de observabilidade;
24. estratégia de testes;
25. requisitos de implantação.

Se alguma informação essencial estiver ausente e impedir uma decisão segura, solicite esclarecimento.

Quando a informação ausente não bloquear a implementação, utilize a alternativa mais simples compatível com o Handbook e registre a decisão.

---

# FASE 2 — PROPOSTA DE ARQUITETURA

Antes de gerar a implementação, crie:

`docs/arquitetura/01-ARQUITETURA-DA-SOLUCAO.md`

O documento deve conter:

- objetivo;
- escopo;
- contexto;
- arquitetura escolhida;
- projetos da solution;
- responsabilidades;
- dependências permitidas;
- integrações;
- persistência;
- segurança;
- configuração;
- observabilidade;
- estratégia de testes;
- decisões técnicas importantes;
- riscos conhecidos;
- diagrama Mermaid.

Utilize como base a arquitetura do Handbook.

Estrutura preferencial:

```text
src/
├── NomeDoSistema.Api/
├── NomeDoSistema.Aplicacao/
├── NomeDoSistema.Dominio/
├── NomeDoSistema.Infraestrutura/
├── NomeDoSistema.Functions/       # somente se necessário
└── NomeDoSistema.Worker/          # somente se necessário

tests/
├── NomeDoSistema.Dominio.Testes/
├── NomeDoSistema.Aplicacao.Testes/
├── NomeDoSistema.Infraestrutura.Testes/
├── NomeDoSistema.Api.Testes.Integracao/
├── NomeDoSistema.Api.Testes.E2E/
├── NomeDoSistema.Functions.Testes/ # somente se houver Functions
└── NomeDoSistema.Worker.Testes/    # somente se houver Worker
```

Não crie projetos vazios ou sem função real.

---

# DEPENDÊNCIAS ARQUITETURAIS

A solução deve respeitar, conceitualmente:

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

A API pode conhecer `Infraestrutura` apenas no Composition Root.

Functions e Workers são hosts e devem reutilizar `Aplicacao` e `Dominio`.

---

# DOMÍNIO

O projeto de domínio:

- não conhece ASP.NET Core;
- não conhece Entity Framework;
- não conhece Dapper;
- não conhece Azure;
- não conhece Dynamics;
- não conhece HTTP;
- não conhece SDKs de terceiros;
- não lê configuração;
- não acessa banco;
- não registra logs de infraestrutura;
- deve preservar regras e invariantes de negócio.

Utilize DDD Lite quando apropriado.

Não introduza complexidade desnecessária.

Evite automaticamente:

- Aggregate Root sofisticado sem necessidade;
- Domain Events sem necessidade;
- Event Sourcing;
- Specifications;
- CQRS framework;
- MediatR apenas por convenção.

---

# APLICAÇÃO

O projeto `Aplicacao` deve:

- coordenar casos de uso;
- depender do domínio;
- definir ports/interfaces necessários;
- trabalhar com abstrações;
- não conhecer implementações de infraestrutura;
- não conhecer Dapper;
- não conhecer EF Core;
- não conhecer Azure SDK;
- não conhecer ServiceClient do Dynamics;
- não acessar diretamente configurações externas.

Exemplo conceitual:

```text
Controller
    ↓
Caso de Uso
    ↓
Port
    ↓
Adapter da Infraestrutura
```

---

# INFRAESTRUTURA

O projeto `Infraestrutura` deve conter implementações relacionadas a:

- banco de dados;
- Entity Framework Core;
- Dapper;
- Dynamics / Dataverse;
- Azure Storage;
- Azure Table Storage;
- Key Vault;
- mensageria;
- APIs externas;
- caches;
- providers;
- SDKs;
- adaptações de serviços externos.

Nenhuma implementação da infraestrutura deve vazar para o domínio.

---

# API

A API é responsável por:

- transporte HTTP;
- autenticação;
- autorização;
- controllers;
- contratos;
- DTOs;
- validação de entrada;
- Problem Details;
- OpenAPI;
- middlewares;
- filtros quando justificados;
- composition root.

Controllers devem ser finos.

Evite:

```text
Controller
  -> banco
  -> Dynamics
  -> regra de negócio
```

Prefira:

```text
Controller
  -> CasoDeUso
  -> Ports
  -> Infraestrutura
```

---

# NOMENCLATURA

Todo código corporativo deve utilizar Português do Brasil.

Isso inclui:

- solution;
- projetos;
- namespaces corporativos;
- diretórios;
- arquivos;
- classes;
- interfaces;
- métodos;
- variáveis de negócio;
- DTOs;
- casos de uso;
- serviços;
- testes.

Exemplo:

```text
SolicitacaoController
CriarSolicitacao
AtualizarSolicitacao
ISolicitacaoRepositorio
SolicitacaoRepositorio
IntegracaoDynamics
ClienteDynamics
SincronizarClienteFunction
ProcessarPedidosWorker
```

Termos técnicos consolidados ou tipos de frameworks podem permanecer em inglês quando necessário, como:

- Controller;
- Middleware;
- Repository;
- Worker;
- BackgroundService;
- HealthCheck;
- OpenAPI;
- Entity Framework;
- Dapper.

Evite uma solution com nomenclatura híbrida sem necessidade.

---

# ENTITY FRAMEWORK CORE OU DAPPER

A escolha deve ser consciente.

## Escolha Entity Framework Core quando:

- produtividade e modelagem forem prioridades;
- houver operações de escrita mais ricas;
- relacionamento entre entidades for relevante;
- change tracking trouxer benefício;
- migrations fizerem sentido;
- LINQ melhorar a manutenção;
- não houver necessidade dominante de controle manual do SQL.

## Escolha Dapper quando:

- houver queries SQL específicas;
- performance de leitura for crítica;
- o banco já possuir SQL consolidado;
- houver grande volume;
- houver necessidade de controle explícito das consultas;
- o modelo relacional não se beneficiar de tracking.

## Pode utilizar ambos quando houver justificativa

Exemplo possível:

```text
EF Core
  -> operações transacionais e escrita

Dapper
  -> consultas otimizadas e relatórios
```

Isso não significa automaticamente CQRS.

Nunca implemente EF Core ou Dapper no Domain ou Application.

---

# ENTITY FRAMEWORK CORE

Quando escolhido:

- mantenha `DbContext` em Infraestrutura;
- configure migrations;
- utilize `AsNoTracking` quando apropriado;
- evite N+1;
- prefira projeções;
- utilize índices compatíveis com consultas;
- configure concorrência quando necessária;
- evite carregar grafos inteiros sem necessidade;
- utilize `CancellationToken`;
- valide comportamento transacional;
- não exponha entidades EF diretamente pela API.

---

# DAPPER

Quando escolhido:

- SQL parametrizado obrigatoriamente;
- nunca concatene dados do usuário no SQL;
- mantenha SQL em Infraestrutura;
- utilize `CancellationToken`;
- controle connections corretamente;
- utilize transações explicitamente quando necessárias;
- implemente paginação determinística;
- avalie OFFSET x keyset pagination;
- valide índices;
- não utilize Generic Repository automaticamente.

---

# BANCO DE DADOS RELACIONAL

Para cada nova tabela:

- defina chave primária;
- tipos adequados;
- nulabilidade;
- constraints;
- índices;
- unicidade;
- datas em UTC quando aplicável;
- estratégia de auditoria quando necessária;
- concorrência;
- retenção quando aplicável.

Não crie índices aleatoriamente.

Os índices devem estar relacionados aos padrões reais de consulta.

---

# DYNAMICS 365 / DATAVERSE

Integrações com Dynamics devem ficar atrás de ports.

Nunca:

```text
Controller -> ServiceClient
Function -> ServiceClient
Worker -> ServiceClient
```

Prefira:

```text
Controller / Function / Worker
        ↓
Aplicacao
        ↓
IPortDynamics
        ↓
AdaptadorDataverse
        ↓
Dynamics
```

## Azure

Para workloads hospedados no Azure:

- utilizar Managed Identity preferencialmente;
- evitar usuário e senha;
- evitar client secret quando Managed Identity for suportada;
- configurar Application User no Dataverse;
- utilizar security role de menor privilégio.

Apenas habilitar Managed Identity no Azure não concede acesso automaticamente ao Dataverse.

A identidade deve ser autorizada corretamente no ambiente do Dynamics.

## Ambiente local

Quando Managed Identity não estiver disponível:

- permitir autenticação do desenvolvedor quando compatível;
- ou Client ID + Client Secret;
- armazenar segredo somente em local seguro;
- nunca versionar segredo.

---

# AZURE MANAGED IDENTITY

Managed Identity deve ser a opção padrão para workloads Azure quando o serviço de destino suportar Microsoft Entra ID.

Aplicável, por exemplo, a:

- Key Vault;
- Azure Storage;
- Azure Table Storage;
- Service Bus;
- SQL Azure, quando configurado;
- outros serviços Azure compatíveis;
- obtenção de token para integração quando suportado.

Em produção, prefira credenciais determinísticas.

Não dependa automaticamente de cadeias genéricas de credenciais quando a identidade esperada da workload já for conhecida.

---

# AZURE KEY VAULT

Segredos de produção devem ficar fora do repositório.

Utilize Key Vault para:

- client secrets inevitáveis;
- API keys;
- certificados;
- connection strings que não possam utilizar identidade;
- credenciais externas.

Acesso ao Key Vault em Azure deve utilizar Managed Identity sempre que possível.

---

# CONFIGURAÇÃO POR AMBIENTE

Padronize:

```text
appsettings.json
appsettings.Development.json
Environment Variables
User Secrets
.env
Azure Key Vault
Azure App Configuration, quando aplicável
```

## Regras

`appsettings.json`:

- configurações não secretas;
- valores padrão seguros.

`appsettings.Development.json`:

- somente desenvolvimento;
- sem credenciais reais versionadas.

User Secrets / `.env`:

- desenvolvimento local;
- nunca versionar arquivos contendo segredos reais.

Environment Variables:

- configuração externa;
- pipeline;
- containers;
- Azure.

Key Vault:

- segredos de ambientes Azure.

Nunca versione:

- password;
- token;
- client secret;
- API key;
- SAS token;
- certificado privado;
- bearer token;
- connection string sensível.

---

# AZURE TABLE STORAGE

Quando utilizado:

- implemente acesso na Infraestrutura;
- abstraia por interface quando necessário;
- utilize Managed Identity no Azure;
- use client secret apenas quando tecnicamente necessário em ambiente local;
- defina conscientemente `PartitionKey`;
- defina conscientemente `RowKey`;
- evite scans completos;
- modele as consultas considerando as características do Table Storage;
- não trate Table Storage como banco relacional.

---

# AZURE FUNCTIONS

Crie Azure Functions apenas se houver necessidade real.

Functions devem atuar como hosts/adapters.

Exemplo:

```text
Trigger
   ↓
Function
   ↓
CasoDeUso
   ↓
Domain
   ↓
Port
   ↓
Infraestrutura
```

Functions não devem duplicar regra de negócio existente na API.

Configure:

- Dependency Injection;
- logging;
- observabilidade;
- Managed Identity;
- Key Vault;
- retry quando apropriado;
- idempotência;
- tratamento de falhas;
- DLQ quando aplicável ao trigger;
- CancellationToken quando suportado.

Crie testes para Functions.

---

# WORKERS

Workers devem utilizar `BackgroundService` ou mecanismo equivalente quando apropriado.

Devem possuir:

- CancellationToken;
- graceful shutdown;
- logging estruturado;
- tratamento de exceções;
- backoff;
- retry controlado;
- idempotência;
- telemetria;
- health/readiness quando aplicável.

Regra de negócio deve permanecer em Domain/Application.

---

# RESILIÊNCIA

Para integrações externas avalie:

- timeout;
- retry;
- exponential backoff;
- jitter;
- circuit breaker;
- idempotência;
- fallback quando fizer sentido;
- bulkhead quando necessário.

Não aplique retries cegamente.

Nunca utilize retry indiscriminado para operações não idempotentes.

---

# API REST

Siga padrões REST definidos no Handbook.

Utilize recursos no plural.

Exemplo:

```text
GET    /api/clientes
GET    /api/clientes/{id}
POST   /api/clientes
PUT    /api/clientes/{id}
PATCH  /api/clientes/{id}
DELETE /api/clientes/{id}
```

Evite:

```text
/api/getClientes
/api/criarCliente
/api/deletarCliente
```

Utilize corretamente:

- 200;
- 201;
- 204;
- 400;
- 401;
- 403;
- 404;
- 409;
- 422 quando justificado;
- 500;
- 503.

Não retorne `200 OK` para todos os cenários.

---

# OPENAPI

A API deve disponibilizar OpenAPI conforme o padrão do Handbook.

Documente:

- endpoints;
- modelos;
- autenticação;
- respostas;
- erros;
- exemplos relevantes.

OpenAPI deve fazer parte dos testes de smoke/integridade quando aplicável.

---

# VALIDAÇÃO

Separe:

```text
validação de entrada
```

de:

```text
invariantes de domínio
```

Exemplo:

```text
campo obrigatório ausente
    -> validação de entrada

transição de estado proibida
    -> regra de domínio
```

Não misture os dois conceitos.

---

# ERROS E PROBLEM DETAILS

Padronize erros utilizando RFC 9457 / Problem Details quando aplicável.

Centralize o tratamento de exceções.

Não espalhe `try/catch` pelos controllers sem necessidade.

Garanta que respostas de erro:

- não vazem stack trace;
- não vazem secrets;
- não exponham detalhes internos;
- possuam correlation ID quando aplicável.

---

# SEGURANÇA

Aplique os padrões de segurança do Handbook.

No mínimo:

- HTTPS;
- autenticação apropriada;
- autorização explícita;
- princípio do menor privilégio;
- SQL parametrizado;
- proteção de secrets;
- validação;
- limits de entrada;
- CORS configurado conscientemente;
- logs sem dados sensíveis;
- dependências atualizadas;
- Managed Identity;
- Key Vault;
- proteção de endpoints administrativos.

Quando aplicável, considerar também:

- OWASP API Security;
- rate limiting;
- threat modeling;
- security headers;
- SAST;
- SCA;
- secret scanning;
- container scanning.

---

# OBSERVABILIDADE

Implemente desde o início:

```text
Logs
Metrics
Traces
```

Utilize OpenTelemetry conforme o padrão do Handbook.

Integre com Application Insights quando aplicável.

Inclua:

- correlation ID;
- duração das requests;
- erros;
- chamadas externas;
- banco;
- Functions;
- Workers.

Nunca registre:

- passwords;
- tokens;
- client secrets;
- chaves privadas;
- informações pessoais sem necessidade.

---

# HEALTH CHECKS

Implemente quando aplicável:

```text
/health/live
/health/ready
```

Liveness:

- processo está vivo.

Readiness:

- aplicação está pronta para receber tráfego;
- dependências críticas disponíveis.

Não coloque toda dependência externa no liveness.

---

# TESTES

A solução deve nascer testável.

Crie testes conforme o risco e responsabilidade.

## Domínio

Testes unitários para:

- regras;
- invariantes;
- transições;
- cálculos.

## Aplicação

Testes dos casos de uso:

- fluxo de sucesso;
- validações;
- erros;
- interação com ports.

Mocks devem representar boundaries, não entidades do domínio.

## Infraestrutura

Testes de integração para:

- Dapper;
- EF Core;
- SQL;
- mapeamentos;
- adapters;
- serialização;
- integrações relevantes.

Quando adequado, utilize banco real em container para testes de integração.

## API

Teste:

- endpoints;
- status codes;
- contratos;
- autenticação;
- autorização;
- Problem Details;
- OpenAPI.

## E2E

Implemente fluxos completos essenciais usando a aplicação efetivamente hospedada para testes.

## Functions

Teste:

- trigger;
- binding;
- caso de uso;
- falhas;
- comportamento do adapter.

## Workers

Teste:

- execução;
- cancelamento;
- caso de uso;
- retry;
- comportamento em falhas.

---

# COBERTURA

Coverage é indicador, não objetivo isolado.

Priorize:

- regras críticas;
- fluxos de negócio;
- contratos;
- segurança;
- persistência;
- integrações;
- cenários de falha.

Não escreva testes inúteis apenas para aumentar percentual.

---

# GIT FLOW

Prepare o projeto para o fluxo definido no Handbook.

Utilize branches como:

```text
main
develop
feature/*
bugfix/*
hotfix/*
release/*
```

Exemplos:

```text
feature/cadastro-clientes
bugfix/correcao-validacao-documento
hotfix/correcao-token-dynamics
release/1.3.0
```

Utilize Conventional Commits conforme o padrão corporativo.

Exemplos:

```text
feat(clientes): adiciona cadastro de cliente
fix(dynamics): corrige obtenção de token
test(pedidos): adiciona cenários e2e
refactor(aplicacao): separa regra de negócio
docs(api): atualiza contrato openapi
chore(deps): atualiza dependências
```

Não faça commits gigantes sem necessidade.

---

# CODE REVIEW

A implementação deve ser criada de forma que outro desenvolvedor consiga revisar facilmente.

Antes de concluir, faça uma auto-revisão procurando:

- responsabilidades misturadas;
- dependências incorretas;
- abstrações desnecessárias;
- duplicação;
- secrets;
- SQL inseguro;
- código morto;
- TODOs não tratados;
- logs sensíveis;
- ausência de testes;
- breaking changes não documentadas;
- bibliotecas sem justificativa;
- nomenclatura fora do padrão;
- comentários redundantes;
- complexidade desnecessária.

---

# DEPENDÊNCIAS

Não adicione pacotes apenas porque são populares.

Antes de adicionar uma dependência:

1. verifique se .NET oferece solução nativa;
2. confirme aderência ao Handbook;
3. avalie manutenção;
4. avalie segurança;
5. avalie necessidade real.

Não introduza automaticamente:

- MediatR;
- AutoMapper;
- Generic Repository;
- FluentResults;
- MassTransit;
- CQRS framework;
- Event Bus;
- Specification Pattern;
- abstrações adicionais;

sem justificativa técnica concreta.

---

# README

Crie um `README.md` profissional contendo:

- objetivo;
- stack;
- arquitetura;
- estrutura;
- dependências;
- execução local;
- configuração;
- banco;
- migrations quando houver;
- autenticação;
- Azure;
- Dynamics;
- Functions;
- Workers;
- testes;
- OpenAPI;
- health checks;
- observabilidade;
- variáveis de ambiente;
- instruções de build;
- instruções de execução;
- limitações conhecidas.

Nunca coloque segredo real no README.

---

# ADRs

Para decisões arquiteturais relevantes, crie ADRs em:

```text
docs/arquitetura/adrs/
```

Exemplos:

```text
ADR-001-PERSISTENCIA-EF-CORE.md
ADR-002-INTEGRACAO-DYNAMICS.md
ADR-003-AUTENTICACAO-MANAGED-IDENTITY.md
```

Não crie ADR para decisões triviais.

---

# BUILD E VALIDAÇÃO CONTÍNUA

Durante a implementação:

1. execute `dotnet restore`;
2. execute `dotnet build`;
3. corrija todos os erros;
4. execute testes unitários;
5. execute testes de integração;
6. execute testes E2E;
7. valide OpenAPI;
8. valide configuração;
9. valide health checks;
10. revise warnings relevantes.

Não acumule código quebrado.

---

# QUALIDADE DE COMPILAÇÃO

Não ignore warnings importantes.

Quando tecnicamente possível:

- Nullable Reference Types habilitado;
- analyzers habilitados;
- warnings relevantes tratados;
- código assíncrono corretamente utilizado;
- CancellationToken propagado em operações I/O.

Não transforme todos os warnings em erro automaticamente sem avaliar o contexto do projeto e o Handbook.

---

# DOCUMENTAÇÃO TÉCNICA FINAL

Ao finalizar, mantenha:

```text
docs/
└── arquitetura/
    ├── 01-ARQUITETURA-DA-SOLUCAO.md
    ├── 02-DECISOES-TECNICAS.md
    ├── 03-INTEGRACOES.md
    ├── 04-SEGURANCA-E-CONFIGURACAO.md
    ├── 05-ESTRATEGIA-DE-TESTES.md
    └── adrs/
```

Não duplique conteúdo que já esteja adequadamente documentado no README.

---

# CRITÉRIOS DE CONCLUSÃO

Não considere a nova API concluída até que:

- a solution esteja organizada;
- os projetos necessários existam;
- projetos desnecessários tenham sido evitados;
- arquitetura esteja aderente ao Handbook;
- dependências estejam corretas;
- Domain esteja isolado;
- Application esteja independente de Infrastructure;
- controllers estejam finos;
- persistência esteja encapsulada;
- Dynamics esteja encapsulado;
- Functions estejam padronizadas;
- Workers estejam padronizados;
- Managed Identity esteja preparada quando aplicável;
- Key Vault esteja previsto/configurado quando aplicável;
- secrets não estejam versionados;
- OpenAPI esteja válido;
- tratamento de erros esteja padronizado;
- validações estejam implementadas;
- health checks estejam implementados quando aplicável;
- observabilidade esteja configurada;
- logs não exponham segredos;
- testes unitários estejam passando;
- testes de integração estejam passando;
- testes E2E estejam passando;
- testes de Functions estejam passando quando houver Functions;
- testes de Workers estejam passando quando houver Worker;
- `dotnet build` conclua sem erros;
- documentação esteja atualizada.

Se algum item não puder ser concluído, registre explicitamente a pendência e o motivo.

Nunca declare uma implementação como pronta escondendo falhas, testes quebrados ou decisões não resolvidas.

---

# ENTREGA FINAL DO AGENTE

Ao terminar, apresente um resumo contendo:

1. arquitetura criada;
2. projetos criados;
3. endpoints implementados;
4. persistência escolhida e justificativa;
5. integrações;
6. estratégia Dynamics;
7. estratégia Azure;
8. Managed Identity;
9. configuração por ambiente;
10. Functions;
11. Workers;
12. testes;
13. observabilidade;
14. segurança;
15. arquivos de documentação criados;
16. comandos para executar localmente;
17. pendências ou riscos.

---

# REGRA FINAL

O `Handbook-Engenharia-Backend-DotNet10-Azure` é a autoridade técnica desta implementação.

A nova API deve nascer aderente ao Handbook e não apenas ser adaptada a ele posteriormente.

Priorize:

```text
Clareza
+ Simplicidade
+ Segurança
+ Testabilidade
+ Observabilidade
+ Manutenibilidade
+ Evolução
```

Não confunda engenharia sênior com quantidade de frameworks, abstrações ou projetos.
