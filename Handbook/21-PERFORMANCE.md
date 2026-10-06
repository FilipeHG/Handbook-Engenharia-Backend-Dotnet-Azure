# 21 — Performance

## Medir antes de otimizar

Definir baseline, carga e SLO. Usar profiling/metrics/trace para localizar gargalo.

## Pontos críticos

- pool de conexões SQL;
- número de round-trips;
- N+1;
- serialização/payload;
- chamadas Dataverse;
- concorrência de Functions/Workers;
- cache e invalidação;
- cold start quando aplicável;
- alocação/memória somente após evidência.

## Load test

Endpoints críticos devem possuir teste de carga em ambiente adequado antes de mudança de capacidade significativa.

## Cache

Cache não é correção automática de query ruim. Definir TTL, ownership, consistência, eviction e comportamento em falha.
