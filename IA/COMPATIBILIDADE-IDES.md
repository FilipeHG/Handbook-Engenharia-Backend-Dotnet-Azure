# Compatibilidade com IDEs e Agentes

| Ferramenta | Arquivo/abordagem |
|---|---|
| OpenAI Codex | `AGENTS.md` na raiz + Handbook referenciado |
| GitHub Copilot | `.github/copilot-instructions.md` |
| Cursor | `.cursor/rules/handbook-backend.mdc` |
| Kiro | `.kiro/steering/handbook.md` |
| Antigravity | anexar/registrar `AGENTS.md` e capítulos do Handbook nas regras/contexto do workspace conforme a versão utilizada |
| Outros agentes | usar `AGENTS.md` como system/project instruction e recuperação seletiva de `Handbook/*.md` |

Não duplicar regras extensas em cada IDE. A fonte canônica é `Handbook/`.
