# 24 — Catálogo de Dependências

## Objetivo

Evitar que cada API selecione bibliotecas diferentes para a mesma responsabilidade.

## Categorias a homologar corporativamente

- OpenAPI/UI;
- validação;
- EF Core / Dapper;
- SQL Client;
- Azure Identity;
- Key Vault/App Configuration;
- Storage Tables/Blob/Queue;
- Service Bus;
- Dataverse Client;
- OpenTelemetry/Azure Monitor;
- testes/mocks/assertions/Testcontainers;
- analyzers/formatters/security scanners.

## Regra

O Handbook define **responsabilidade e padrão arquitetural**; o catálogo corporativo define **pacote e versão aprovada**. Isso permite atualizar dependências sem reescrever a arquitetura.

Dependência nova que introduz runtime/framework transversal requer avaliação de Tech Lead/Arquitetura.
