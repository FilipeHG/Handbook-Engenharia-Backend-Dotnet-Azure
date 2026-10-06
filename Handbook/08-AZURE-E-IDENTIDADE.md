# 08 — Azure e Identidade

## Princípio

**Passwordless-first** para workloads hospedados em Azure.

### Desenvolvimento local

- Azure CLI / Visual Studio / VS Code autenticado: `DefaultAzureCredential` ou cadeia explícita de credenciais de desenvolvedor.
- Client Secret é permitido apenas quando o serviço alvo exigir S2S e a identidade do desenvolvedor não for apropriada.
- segredo local deve ficar em User Secrets, `.env` ignorado pelo Git ou secret store corporativo.

### Azure DEV/HML/PROD

Preferir credencial determinística:

```csharp
TokenCredential credencial = ambiente.IsDevelopment()
    ? new DefaultAzureCredential()
    : new ManagedIdentityCredential();
```

Para User Assigned Managed Identity, configure explicitamente o client ID da identidade.

## Serviços comuns

- Key Vault — segredos, certificados e chaves.
- Azure App Configuration — configuração central não-secreta e referências a Key Vault.
- Azure SQL — identidade Entra quando disponível.
- Storage / Tables / Blobs / Queues — RBAC + Managed Identity.
- Service Bus — RBAC + Managed Identity.
- Application Insights / Azure Monitor — telemetria via OpenTelemetry/Azure Monitor exporter.

## Least privilege

Cada workload deve possuir somente roles necessárias. Não reutilizar uma única identidade “superadmin” entre múltiplos microserviços.
