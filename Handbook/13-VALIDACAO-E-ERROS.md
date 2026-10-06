# 13 — Validação e Tratamento de Erros

## Camadas de validação

1. Request/contrato — formato, obrigatoriedade, range.
2. Application — pré-condições do caso de uso.
3. Domain — invariantes reais do negócio.
4. Banco/integração — constraints finais e conflitos concorrentes.

## Problem Details

Usar RFC 9457/Problem Details de forma centralizada.

```json
{
  "type": "https://empresa/errors/regra-de-negocio",
  "title": "Operação não permitida",
  "status": 409,
  "detail": "Uma solicitação concluída não pode retornar para aberta.",
  "traceId": "..."
}
```

## Middleware/handler central

Mapear exceções conhecidas para status previsíveis. Exceção não mapeada gera 500 e log estruturado com traceId.

Não retornar mensagens internas de SQL, Dataverse, Key Vault ou stack trace ao consumidor.
