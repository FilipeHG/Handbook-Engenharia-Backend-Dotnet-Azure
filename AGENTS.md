# Instruções para Agentes de IA

Este repositório contém normas corporativas de engenharia. Antes de alterar ou gerar código:

1. Leia `Handbook/00-MAPA-DO-HANDBOOK.md` e os capítulos relacionados à tarefa.
2. Não invente arquitetura, bibliotecas ou padrões não autorizados.
3. Preserve a regra corporativa de nomenclatura em Português do Brasil.
4. Não coloque segredos, tokens, connection strings ou client secrets em código, README ou appsettings versionados.
5. Prefira Managed Identity em workloads Azure; localmente use identidade do desenvolvedor ou client secret somente quando necessário e armazenado fora do Git.
6. Não faça controllers acessarem banco, SDK do Dataverse ou clientes Azure diretamente.
7. Não faça Domain depender de Infrastructure, Azure, ASP.NET Core, EF Core, Dapper ou Dataverse SDK.
8. Antes de concluir uma mudança, valide build, testes, contratos OpenAPI, segurança e observabilidade.
9. Para novas APIs use `Modelo-API/` como referência.
10. Para legados siga `Handbook/20-UPGRADE-DE-APIS-LEGADAS.md`.

## Prioridade de instruções

Requisito explícito do projeto > ADR do projeto > Handbook corporativo > exemplo/template.

Se houver conflito não resolvível, pare a alteração arquitetural e sinalize o conflito no resultado.
