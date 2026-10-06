# 19 — CI/CD

## Pipeline mínimo

```mermaid
flowchart LR
  C[Commit/PR] --> R[Restore]
  R --> B[Build]
  B --> A[Analyzers/SAST/secret scan]
  A --> U[Unit tests]
  U --> I[Integration tests]
  I --> O[OpenAPI/contract]
  O --> P[Package/Container]
  P --> D[Deploy Dev]
  D --> E[E2E/Smoke]
  E --> G[Approval/Policy]
  G --> PRD[Deploy Prod]
  PRD --> V[Health/telemetria]
```

## Regras

- branch protection;
- build reproduzível;
- versões de pacote controladas;
- artefato promovido entre ambientes, evitando recompilar de forma diferente;
- secrets obtidos pelo pipeline via identidade/secret store;
- migrations com estratégia de compatibilidade/rollback;
- IaC para recursos Azure relevantes;
- deploy deve observar health e possibilitar rollback.

## Estratégias

Blue/green, canary e deployment slots são recomendados quando custo/criticidade justificarem.
