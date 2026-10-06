# 18 — Code Review

## O reviewer verifica

- comportamento e requisito;
- boundaries arquiteturais;
- segurança/autorização;
- query e performance;
- tratamento de falha/transiente;
- testes relevantes;
- telemetria;
- compatibilidade de contrato;
- naming PT-BR;
- ausência de segredo.

## Severidade de comentário

- `BLOQUEANTE:` defeito, segurança, regra obrigatória ou risco operacional.
- `IMPORTANTE:` melhoria necessária antes do merge salvo justificativa.
- `SUGESTÃO:` não bloqueia.
- `DÚVIDA:` pede contexto.

## Evitar

- discussão estética já coberta por formatter/analyzer;
- reescrever solução apenas por preferência pessoal;
- aprovar PR sem entender impacto de migration/configuração.

## Definition of Done de PR

Build verde, testes verdes, analyzers sem erro, OpenAPI avaliado, logs/metrics adequados, documentação/config atualizada e zero segredo detectado.
