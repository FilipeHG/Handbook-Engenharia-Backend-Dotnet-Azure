# Prompt — Criar Nova API

```text
Você é um agente de engenharia atuando neste repositório corporativo.
Antes de gerar código, leia AGENTS.md e os capítulos 01, 02, 03, 04, 08, 11, 12, 14, 15 e 22 do Handbook.

Objetivo: criar uma nova API .NET 10 chamada <NOME>.
Contexto funcional: <DESCREVER>.
Integrações: <DATAVERSE/SQL/TABLE STORAGE/SERVICE BUS/OUTRAS>.
Persistência: <EF CORE|DAPPER|RECOMENDAR>.
Hosts adicionais: <FUNCTIONS|WORKER|NENHUM>.

Requisitos:
- nomenclatura em Português do Brasil;
- seguir o Modelo-API e a Dependency Rule;
- incluir OpenAPI, Problem Details, health, observabilidade e CancellationToken;
- autenticação/autorizações conforme Handbook;
- Managed Identity nos ambientes Azure sempre que suportado;
- secrets locais somente fora do Git;
- testes unitários, integração e E2E dos fluxos críticos;
- não adicionar CQRS/MediatR/event bus/cache sem necessidade explícita.

Antes de finalizar, apresente:
1. árvore de arquivos criada;
2. decisões e suposições;
3. comandos de build/test;
4. configurações necessárias por ambiente;
5. riscos ou pendências.
```
