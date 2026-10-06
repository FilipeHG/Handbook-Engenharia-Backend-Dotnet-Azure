# Handbook de Engenharia Backend — .NET + Azure

> Plataforma corporativa de conhecimento para criação, manutenção e modernização de APIs Backend em **.NET 10+ LTS**, com serviços Azure, Microsoft Dataverse/Dynamics 365, banco relacional, Azure Functions, Workers, testes, segurança, observabilidade e entrega contínua.

## Objetivo

Este repositório é a **fonte normativa** para times Backend. Ele deve orientar pessoas, revisores e agentes de IA. Em caso de conflito entre um exemplo e uma regra do Handbook, **a regra do Handbook prevalece**.

## Escopo obrigatório

- ASP.NET Core / .NET 10 LTS.
- Português do Brasil em solution, projetos, pastas, arquivos, tipos, membros de domínio, documentação e mensagens de negócio.
- REST + OpenAPI 3.1.
- Clean Architecture pragmática / arquitetura em camadas com dependências direcionadas.
- Azure como plataforma principal.
- Microsoft Dataverse / Dynamics 365 via OAuth, sem usuário/senha em integrações server-to-server.
- Managed Identity como padrão para workloads hospedados em Azure quando o recurso suporta Microsoft Entra ID.
- EF Core **ou** Dapper, escolhidos pelo contexto e isolados atrás de ports da aplicação.
- Testes unitários, integração e E2E.
- Observabilidade, segurança, resiliência, revisão de código e CI/CD.

## Ordem de leitura

1. `Handbook/00-MAPA-DO-HANDBOOK.md`
2. `Handbook/01-PRINCIPIOS-E-REGRAS.md`
3. `Handbook/02-ARQUITETURA-BACKEND.md`
4. `Handbook/03-CONVENCOES-PORTUGUES-BR.md`
5. Demais capítulos conforme a necessidade.
6. `IA/00-COMO-USAR-COM-AGENTES.md` antes de usar Codex, Cursor, Kiro, Copilot ou outro agente.
7. `Modelo-API/README.md` para iniciar um novo microserviço.

## Artefatos principais

- `Handbook/` — normas e decisões de engenharia.
- `Modelo-API/` — modelo de solution para APIs pequenas/médias e microserviços.
- `IA/` — instruções, prompts e regras para agentes de desenvolvimento.
- `Portal/handbook.html` — versão visual do Handbook.
- `Fontes/FONTES-OFICIAIS.md` — fontes oficiais e data de validação.
- `PROMPT-CRIAR-NOVA-API.md` — prompt mestre para criação de novas APIs do zero seguindo integralmente o Handbook.
- `PROMPT-REFATORAR-SOLUTION.md` — prompt mestre para modernização e refatoração de solutions existentes fora do padrão arquitetural.

## Prompts de execução para agentes de IA

Os prompts abaixo são **universais** e podem ser utilizados em Codex, Cursor, Kiro, GitHub Copilot, Antigravity ou qualquer outra IDE/agente de IA que consiga ler os arquivos do repositório.

A regra é simples: o agente deve considerar o `AGENTS.md`, o `README.md`, o `INDICE.md` e todo o conteúdo relevante do Handbook como fonte normativa antes de executar qualquer alteração.

### Criar uma nova API do zero

Arquivo:

`PROMPT-CRIAR-NOVA-API.md`

Utilize este prompt quando uma nova API ou microserviço precisar ser criado do zero já aderente ao padrão corporativo.

#### Plain text de execução

```text
Leia integralmente a pasta Handbook-Engenharia-Backend-DotNet10-Azure.

Considere obrigatoriamente como fonte normativa:
- AGENTS.md
- README.md
- INDICE.md
- Handbook/
- Fontes/
- IA/
- Modelo-API/

Em seguida, execute integralmente as instruções contidas em:

PROMPT-CRIAR-NOVA-API.md

Crie a nova API com base nos requisitos funcionais e técnicos que vou fornecer a seguir.

Antes de criar código, faça o entendimento do contexto e proponha a arquitetura conforme definido no prompt e no Handbook.

Não ignore nenhuma regra obrigatória da documentação.
```

Depois desse comando, informe os requisitos da nova API, por exemplo:

```text
Nome: IntegracaoPedidos

Objetivo:
Criar uma API responsável por consultar pedidos no Dynamics,
persistir o estado de processamento no SQL Server e disponibilizar
endpoints REST para consulta e reprocessamento.

Requisitos:
- .NET 10
- SQL Server
- Dapper
- Dynamics Dataverse
- Managed Identity em Azure
- Azure Function para sincronização periódica
- Azure Table Storage para controle de processamento
- testes unitários, integração e E2E
```

### Refatorar ou modernizar uma solution existente

Arquivo:

`PROMPT-REFATORAR-SOLUTION.md`

Utilize este prompt quando uma API, solution, Function ou Worker existente estiver fora do padrão corporativo e precisar ser reorganizado, modernizado ou atualizado para seguir o Handbook.

#### Plain text de execução

```text
Leia integralmente a pasta Handbook-Engenharia-Backend-DotNet10-Azure.

Considere obrigatoriamente como fonte normativa:
- AGENTS.md
- README.md
- INDICE.md
- Handbook/
- Fontes/
- IA/
- Modelo-API/

Analise integralmente a solution atual e, em seguida, execute todas as instruções contidas em:

PROMPT-REFATORAR-SOLUTION.md

Comece obrigatoriamente pelo inventário e diagnóstico arquitetural.

Não altere código antes de concluir:
1. inventário da solution;
2. análise de aderência ao Handbook;
3. diagnóstico arquitetural;
4. arquitetura de destino;
5. plano incremental de migração.

Depois disso, execute a refatoração de forma incremental, validando restore, build e testes após cada etapa relevante.

Não ignore nenhuma regra obrigatória da documentação.
```

Esse fluxo deve ser utilizado principalmente para:

- APIs legadas;
- solutions criadas fora da arquitetura definida;
- Functions com regras de negócio duplicadas;
- Workers fora do padrão;
- projetos com acesso direto a banco ou Dynamics;
- projetos sem separação adequada entre domínio, aplicação e infraestrutura;
- aplicações sem testes suficientes;
- soluções com secrets ou configurações inadequadas;
- upgrades para .NET 10;
- modernização de observabilidade, segurança e integração com Azure.

## Como os agentes devem interpretar a documentação

Os agentes de IA devem seguir esta ordem de prioridade:

1. `AGENTS.md`
2. regras obrigatórias do `Handbook/`
3. decisões arquiteturais registradas no projeto
4. instruções do prompt executado
5. exemplos contidos em `Modelo-API/`
6. preferência da IDE ou comportamento padrão da ferramenta

Quando houver conflito, a regra de nível superior prevalece.

Nenhum agente deve introduzir automaticamente frameworks, padrões ou abstrações fora do Handbook apenas porque fazem parte das preferências padrão da ferramenta.

## Níveis normativos

- **OBRIGATÓRIO** — deve ser seguido; exceção exige ADR e aprovação técnica.
- **RECOMENDADO** — padrão preferencial; desvio deve ser justificável no PR.
- **OPCIONAL** — ferramenta/padrão permitido para cenários específicos.
- **PROIBIDO** — não deve ser usado em novos desenvolvimentos.

## Regra de exceção

Quando um sistema legado impedir a aplicação imediata de uma regra:

1. registrar dívida técnica;
2. não ampliar o padrão legado para código novo;
3. encapsular a incompatibilidade;
4. criar plano incremental;
5. documentar a exceção em ADR quando arquitetural.
