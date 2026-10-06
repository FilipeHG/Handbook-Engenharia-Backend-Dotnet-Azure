# Configuração por ambiente

| Item | Local | Dev/Hml | Prod |
|---|---|---|---|
| Azure SDK | DefaultAzureCredential / login do dev | ManagedIdentityCredential | ManagedIdentityCredential |
| Dataverse | identidade do dev quando permitido ou App Registration + segredo local | Managed Identity + Application User preferencial | Managed Identity + Application User preferencial |
| Client Secret | User Secrets/.env ignorado | Key Vault somente se inevitável | Key Vault somente se inevitável |
| Table Storage | identidade do dev | RBAC + Managed Identity | RBAC + Managed Identity |
| SQL | local/container/credencial dev | Entra/MI preferencial | Entra/MI preferencial |
| config não secreta | appsettings | env/App Configuration | env/App Configuration |
