# Criação da Solution a partir do modelo

> Execute com SDK .NET 10 instalado. Ajuste `Empresa.Modelo` antes de iniciar.

```bash
mkdir Empresa.Modelo && cd Empresa.Modelo

dotnet new sln -n Empresa.Modelo
mkdir src tests

dotnet new webapi   -n Empresa.Modelo.Api             -o src/Empresa.Modelo.Api --framework net10.0
dotnet new classlib -n Empresa.Modelo.Aplicacao       -o src/Empresa.Modelo.Aplicacao --framework net10.0
dotnet new classlib -n Empresa.Modelo.Dominio         -o src/Empresa.Modelo.Dominio --framework net10.0
dotnet new classlib -n Empresa.Modelo.Infraestrutura  -o src/Empresa.Modelo.Infraestrutura --framework net10.0
dotnet new worker   -n Empresa.Modelo.Worker           -o src/Empresa.Modelo.Worker --framework net10.0

dotnet new xunit -n Empresa.Modelo.Testes.Unitarios   -o tests/Empresa.Modelo.Testes.Unitarios --framework net10.0
dotnet new xunit -n Empresa.Modelo.Testes.Integracao -o tests/Empresa.Modelo.Testes.Integracao --framework net10.0
dotnet new xunit -n Empresa.Modelo.Testes.E2E        -o tests/Empresa.Modelo.Testes.E2E --framework net10.0
```

Para Azure Functions, utilizar o template/tooling corporativo homologado para **.NET isolated worker** compatível com .NET 10.

## Referências entre projetos

```bash
dotnet add src/Empresa.Modelo.Aplicacao reference src/Empresa.Modelo.Dominio

dotnet add src/Empresa.Modelo.Infraestrutura reference src/Empresa.Modelo.Aplicacao
dotnet add src/Empresa.Modelo.Infraestrutura reference src/Empresa.Modelo.Dominio

dotnet add src/Empresa.Modelo.Api reference src/Empresa.Modelo.Aplicacao
dotnet add src/Empresa.Modelo.Api reference src/Empresa.Modelo.Infraestrutura

dotnet add src/Empresa.Modelo.Worker reference src/Empresa.Modelo.Aplicacao
dotnet add src/Empresa.Modelo.Worker reference src/Empresa.Modelo.Infraestrutura
```

## Pacotes por responsabilidade

Instalar somente os pacotes necessários ao perfil escolhido, usando as versões aprovadas pelo catálogo corporativo no momento do bootstrap.

### API

```bash
dotnet add src/Empresa.Modelo.Api package Microsoft.AspNetCore.OpenApi
```

### EF Core / SQL Server

```bash
dotnet add src/Empresa.Modelo.Infraestrutura package Microsoft.EntityFrameworkCore.SqlServer
dotnet add src/Empresa.Modelo.Infraestrutura package Microsoft.EntityFrameworkCore.Design
```

### Dapper / SQL Server

```bash
dotnet add src/Empresa.Modelo.Infraestrutura package Dapper
dotnet add src/Empresa.Modelo.Infraestrutura package Microsoft.Data.SqlClient
```

### Azure + Dataverse + Table Storage

```bash
dotnet add src/Empresa.Modelo.Infraestrutura package Azure.Identity
dotnet add src/Empresa.Modelo.Infraestrutura package Azure.Data.Tables
dotnet add src/Empresa.Modelo.Infraestrutura package Microsoft.PowerPlatform.Dataverse.Client
```

### Observabilidade

Usar os pacotes OpenTelemetry/Azure Monitor homologados pela plataforma corporativa. Não adicionar exporters diferentes por microserviço sem decisão de plataforma.

## Regra de dependência

Após criar a solution, valide que **nenhuma referência** foi criada de Domain/Application para API/Infrastructure.
