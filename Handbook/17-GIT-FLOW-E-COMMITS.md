# 17 — Git Flow, Branches e Commits

## Modelo corporativo recomendado

Um **Git Flow simplificado**, compatível com entrega contínua.

```mermaid
gitGraph
  commit id: "main"
  branch develop
  checkout develop
  commit id: "integração"
  branch feature/123-criar-solicitacao
  checkout feature/123-criar-solicitacao
  commit id: "feat"
  checkout develop
  merge feature/123-criar-solicitacao
  branch release/1.4.0
  checkout release/1.4.0
  commit id: "ajustes release"
  checkout main
  merge release/1.4.0 tag: "v1.4.0"
  checkout develop
  merge release/1.4.0
```

## Branches

- `main` — produção; protegida; somente PR/release/hotfix.
- `develop` — integração, quando o produto realmente usa cadência Git Flow.
- `feature/<ticket>-<slug>` — desenvolvimento novo.
- `bugfix/<ticket>-<slug>` — correção não urgente antes de produção.
- `hotfix/<ticket>-<slug>` — correção urgente iniciada a partir de `main`.
- `release/<versao>` — estabilização, quando houver janela formal de release.
- `chore/...`, `docs/...`, `refactor/...` — manutenção técnica curta.

> Times com trunk-based delivery podem omitir `develop`/`release` mediante decisão registrada. Branches devem continuar curtas.

## Hotfix

```mermaid
flowchart LR
  M[main] --> H[hotfix/INC-123-corrigir-timeout]
  H --> PR[PR + testes + review]
  PR --> M2[main + tag]
  M2 --> D[merge/cherry-pick para develop]
```

## Commits

Usar Conventional Commits em PT-BR no texto:

```text
feat(solicitacoes): adiciona criação de solicitação
fix(dataverse): trata throttling 429
refactor(persistencia): extrai consulta para repositório
perf(clientes): reduz round-trips no SQL
security(auth): restringe audience aceita
chore(deps): atualiza pacotes aprovados
```

Commits devem ser pequenos, coerentes e compiláveis sempre que possível. Não usar “ajustes”, “fix”, “final” sem contexto.

## PR

Título objetivo, ticket, impacto, evidência de teste, risco, migração/configuração e observabilidade.
