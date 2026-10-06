# 11 — Configuração, `.env`, appsettings e Key Vault

## Hierarquia recomendada

```text
appsettings.json                 # defaults não sensíveis
appsettings.Development.json     # defaults locais não sensíveis
User Secrets / .env ignorado     # segredo local quando necessário
Environment Variables            # override de ambiente
Azure App Configuration          # configuração central opcional
Azure Key Vault                  # segredos/certificados/chaves
```

## `.env`

`.env` pode existir para experiência local, mas:

- deve estar no `.gitignore`;
- repositório contém apenas `.env.example` sem segredo;
- aplicação ASP.NET Core não lê `.env` por mágica: biblioteca/bootstrapping deve ser explícito caso adotado;
- em Azure, preferir settings da plataforma + App Configuration/Key Vault.

## Convenção de ambiente

- Local
- Dev
- Hml/Staging
- Prod

## Client Secret

Somente quando necessário:

```text
Local: User Secrets ou .env local ignorado
Dev/Hml: Key Vault do ambiente
Prod: preferir Managed Identity; se segredo inevitável, Key Vault + rotação
```

## Options

```csharp
builder.Services
    .AddOptions<ConfiguracaoDataverse>()
    .Bind(builder.Configuration.GetSection("Dataverse"))
    .ValidateDataAnnotations()
    .ValidateOnStart();
```

Falhar cedo em configuração obrigatória inválida.
