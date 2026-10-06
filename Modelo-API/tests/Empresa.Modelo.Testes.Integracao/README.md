# Testes de Integração

Cobrir implementações reais de Infrastructure:

- EF Core ou Dapper contra SQL Server efêmero/homologado;
- mapping de dados e constraints;
- Azure Table Storage via Azurite quando compatível, ou recurso de teste isolado;
- cliente Dataverse por contrato/ambiente controlado quando necessário;
- políticas de retry/timeout e tratamento de erros transitórios.

Para SQL, Testcontainers é recomendado quando o executor de CI disponibilizar runtime de containers.
