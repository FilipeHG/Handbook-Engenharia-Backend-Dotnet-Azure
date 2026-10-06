# 06 — Banco de Dados Relacional

## Regras

- schema versionado via migrations/scripts auditáveis;
- nomes consistentes e alinhados ao domínio corporativo;
- constraints no banco complementam, não substituem, validações da aplicação;
- índices criados a partir de consultas reais;
- evitar `SELECT *` em código de produção;
- usar transação somente quando existir unidade atômica real;
- queries devem receber `CancellationToken` quando a biblioteca permitir;
- UTC para instantes; cuidado explícito com fuso na borda.

## Paginação

OFFSET é aceitável para páginas moderadas. Para grande volume e navegação sequencial, preferir keyset/seek pagination.

## Concorrência

Quando atualizações concorrentes são possíveis, avaliar:

- `rowversion`/ETag;
- optimistic concurrency;
- isolamento transacional;
- idempotência;
- lock distribuído somente como último recurso e com lease/timeout.

## Azure SQL

Preferir autenticação Microsoft Entra/Managed Identity quando suportada pelo ambiente corporativo, evitando senha de banco persistida em configuração.
