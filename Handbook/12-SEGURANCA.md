# 12 — Segurança

## Baseline

- Microsoft Entra ID/OAuth 2.0/OIDC para autenticação corporativa.
- autorização por policies/roles/claims; autenticação não implica autorização.
- least privilege em RBAC Azure e security roles Dataverse.
- segredo fora do Git.
- HTTPS obrigatório.
- dependências e imagens escaneadas.
- inputs com limite de tamanho e validação.

## API

- validar issuer, audience, assinatura e lifetime do JWT.
- nunca aceitar token apenas por parse do payload.
- configurar CORS por allowlist, não `AllowAnyOrigin` em produção sem justificativa.
- rate limiting para endpoints expostos quando aplicável.
- não expor stack trace ao consumidor.
- headers de segurança adequados ao hosting.

## OWASP

Threat modeling deve considerar pelo menos OWASP API Security Top 10 e abuso de integração: BOLA/IDOR, mass assignment, SSRF, unrestricted resource consumption e falhas de autorização.

## Dados sensíveis

Classificar PII/segredos. Logs, traces e Application Insights devem mascarar ou excluir dados protegidos.

## Supply chain

CI deve executar restore confiável, análise de vulnerabilidades, secret scanning e controles de origem de pacotes conforme política corporativa.
