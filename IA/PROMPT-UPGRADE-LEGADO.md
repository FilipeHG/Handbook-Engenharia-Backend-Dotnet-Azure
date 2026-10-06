# Prompt — Upgrade de API Legada

```text
Analise a API legada e leia AGENTS.md + Handbook/20-UPGRADE-DE-APIS-LEGADAS.md.
Não faça reescrita big-bang.

Entregue primeiro um inventário: framework, pacotes, auth, endpoints, persistência, Dataverse, jobs, config/secrets, observabilidade, deploy e testes existentes.
Depois crie um plano incremental para .NET 10, priorizando segurança, compatibilidade, testes de caracterização e observabilidade.

Ao implementar:
- preserve contrato externo salvo requisito explícito;
- não espalhe arquitetura nova por toda a solução de uma vez;
- crie boundaries em fatias pequenas;
- remova usuário/senha e secrets versionados;
- adote Managed Identity onde suportado;
- acrescente testes antes de refatoração de comportamento;
- registre incompatibilidades/ADRs.
```
