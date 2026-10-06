# Fontes Oficiais

Validação de referências: **2026-10-05**.

Priorizar documentação oficial Microsoft e políticas internas da empresa.

- .NET support policy: https://dotnet.microsoft.com/platform/support/policy/dotnet-core
- ASP.NET Core OpenAPI: https://learn.microsoft.com/aspnet/core/fundamentals/openapi/overview?view=aspnetcore-10.0
- Azure Identity best practices: https://learn.microsoft.com/dotnet/azure/sdk/authentication/best-practices
- User-assigned Managed Identity (.NET): https://learn.microsoft.com/dotnet/azure/sdk/authentication/user-assigned-managed-identity
- Key Vault / App Configuration: https://learn.microsoft.com/azure/azure-app-configuration/use-key-vault-references-dotnet-core
- Azure Tables + token credential: https://learn.microsoft.com/dotnet/api/overview/azure/microsoft.azure.webjobs.extensions.tables-readme
- Dataverse authentication: https://learn.microsoft.com/power-apps/developer/data-platform/authentication
- Dataverse OAuth: https://learn.microsoft.com/power-apps/developer/data-platform/authenticate-oauth
- Dataverse ServiceClient: https://learn.microsoft.com/dotnet/api/microsoft.powerplatform.dataverse.client.serviceclient
- Dataverse S2S: https://learn.microsoft.com/power-apps/developer/data-platform/use-single-tenant-server-server-authentication
- Power Platform Managed Identity overview: https://learn.microsoft.com/power-platform/admin/managed-identity-overview

## Nota sobre Managed Identity + Dataverse

A documentação Microsoft possui cenários distintos de Managed Identity no ecossistema Power Platform. O Handbook usa o padrão de workload Azure obtendo token via Azure Identity e entregando o token ao `ServiceClient`, mas o tenant precisa estar corretamente provisionado para reconhecer o principal como Application User e aplicar security roles. Validar o desenho final com a administração Power Platform/Entra da empresa antes do rollout.
