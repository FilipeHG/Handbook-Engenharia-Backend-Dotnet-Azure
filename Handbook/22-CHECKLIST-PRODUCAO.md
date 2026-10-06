# 22 — Checklist de Produção

## Arquitetura
- [ ] Dependências respeitam boundaries.
- [ ] Sem regra de negócio em controller/trigger.
- [ ] Exceções arquiteturais documentadas.

## Segurança
- [ ] Nenhum segredo versionado.
- [ ] Managed Identity/RBAC aplicados onde possível.
- [ ] Dataverse Application User com least privilege.
- [ ] AuthN/AuthZ testadas.
- [ ] SCA/secret scan sem achado crítico.

## Dados
- [ ] Migration/script revisado.
- [ ] Índices avaliados.
- [ ] Concorrência e rollback considerados.

## Testes
- [ ] Unitários de regras críticas.
- [ ] Integração de persistência.
- [ ] E2E/smoke de caminhos críticos.

## Operação
- [ ] Logs estruturados.
- [ ] Traces/métricas.
- [ ] `/health/live` e `/health/ready` quando aplicável.
- [ ] alertas e dashboard.
- [ ] runbook/owner.

## Deploy
- [ ] Configuração de cada ambiente validada.
- [ ] rollback definido.
- [ ] compatibilidade de contrato avaliada.
