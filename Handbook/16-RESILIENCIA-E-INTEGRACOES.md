# 16 — Resiliência e Integrações

## Regras

- timeout explícito;
- retries apenas para falhas transitórias;
- exponential backoff + jitter;
- respeitar `Retry-After`;
- circuit breaker quando dependência instável justificar;
- idempotência para comandos reexecutáveis;
- bulkhead/limite de concorrência para proteger dependências.

## Retry não pode multiplicar carga

Evitar retry em cascata em múltiplas camadas. Definir responsabilidade única por integração.

## Mensageria

Quando usar Service Bus:

- mensagem com ID/correlationId;
- consumidor idempotente;
- DLQ monitorada;
- TTL e MaxDeliveryCount intencionais;
- schema/versionamento de evento;
- Outbox quando consistência entre banco e publicação for requisito.
