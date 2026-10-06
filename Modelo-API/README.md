# Modelo de API REST / Microserviço .NET 10

Modelo arquitetural para serviço pequeno/médio com poucas controllers, integrações Dataverse, banco relacional, Azure Table Storage e hosts opcionais Function/Worker.

## Estrutura

```text
src/
  Empresa.Modelo.Api
  Empresa.Modelo.Aplicacao
  Empresa.Modelo.Dominio
  Empresa.Modelo.Infraestrutura
  Empresa.Modelo.Functions
  Empresa.Modelo.Worker
tests/
  Empresa.Modelo.Testes.Unitarios
  Empresa.Modelo.Testes.Integracao
  Empresa.Modelo.Testes.E2E
```

## Como adaptar

Substitua `Empresa.Modelo` pelo nome corporativo. Remova `Functions` ou `Worker` quando não forem necessários. Escolha EF Core ou Dapper seguindo `Handbook/07-EF-CORE-X-DAPPER.md`.

## Importante

Os arquivos são um **blueprint didático e arquitetural**. Versões de pacotes devem seguir o catálogo corporativo aprovado no momento da criação do projeto.
