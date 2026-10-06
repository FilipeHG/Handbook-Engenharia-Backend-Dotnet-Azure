# Uso do Handbook com Agentes de IA

## Objetivo

Permitir que Codex, Cursor, Kiro, GitHub Copilot, Antigravity e agentes internos gerem/manutenham código sem “inventar” padrões fora da plataforma corporativa.

## Estratégia

1. `AGENTS.md` na raiz contém regras universais.
2. IDE-specific instructions apontam para os mesmos capítulos do Handbook.
3. Prompts não repetem todo o Handbook; instruem o agente a lê-lo.
4. Decisões específicas do repositório ficam em `docs/ADRs` do projeto.

## Contexto mínimo para nova API

- requisito funcional;
- nome corporativo do serviço;
- integrações (Dataverse, SQL, Storage, Service Bus etc.);
- EF ou Dapper — ou autorização para o agente recomendar;
- hosting (App Service, Container Apps, Functions etc.);
- autenticação dos consumidores;
- ambientes.

## Regra anti-alucinação arquitetural

Se o agente não encontrar uma decisão no Handbook/ADR, ele deve:

1. escolher a alternativa mais simples entre as permitidas;
2. declarar a suposição;
3. não introduzir framework estrutural novo sem ADR.
