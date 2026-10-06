# 15 — Observabilidade

## Padrão

Logs + Metrics + Traces com OpenTelemetry e integração Azure Monitor/Application Insights conforme plataforma.

## Logs estruturados

```csharp
logger.LogInformation(
    "Solicitação {SolicitacaoId} enviada ao Dataverse em {DuracaoMs}ms",
    id, duracao.TotalMilliseconds);
```

Não interpolar string quando campos estruturados são úteis.

## Correlação

Propagar W3C Trace Context (`traceparent`) e correlation ID de negócio quando existir.

## Métricas

- taxa de requests;
- latência p50/p95/p99;
- erros por operação;
- chamadas Dataverse/SQL/Storage;
- retry/throttling;
- fila/lag para consumers.

## Health

Separar:

- `/health/live` — processo está vivo;
- `/health/ready` — apto a receber tráfego.

Liveness não deve falhar porque SQL está indisponível; readiness pode.

## Alertas

Alertar sintoma acionável, não qualquer log de erro. Toda regra de alerta crítica precisa de owner e runbook.
