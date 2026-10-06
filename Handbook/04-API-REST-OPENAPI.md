# 04 — APIs REST, HTTP e OpenAPI

## Convenções de rota

Recursos no plural e substantivos:

```http
GET    /api/v1/solicitacoes
GET    /api/v1/solicitacoes/{id}
POST   /api/v1/solicitacoes
PATCH  /api/v1/solicitacoes/{id}/status
DELETE /api/v1/solicitacoes/{id}
```

Evitar `/criarSolicitacao`, `/getAll` e verbos redundantes.

## Status codes

- 200: leitura/alteração com corpo.
- 201: criação; preferir `CreatedAtAction`.
- 204: sucesso sem corpo.
- 400: request estruturalmente inválido.
- 401: não autenticado.
- 403: autenticado sem permissão.
- 404: recurso não localizado.
- 409: conflito de estado/invariante.
- 422: opcional para semântica inválida quando padrão do produto exigir.
- 429: rate limit.
- 500: falha inesperada.
- 503: dependência crítica indisponível/readiness.

## OpenAPI

- Usar suporte nativo do ASP.NET Core para documento OpenAPI 3.1.
- Contrato deve fazer parte do CI.
- Operações, request/response e códigos relevantes devem estar documentados.
- UI Swagger/ReDoc/Scalar é opcional e não substitui o JSON OpenAPI.

## Versionamento

Versão explícita quando o serviço possuir consumidores independentes e evolução incompatível. Mudanças aditivas preferencialmente mantêm a mesma versão.

## Idempotência

POSTs financeiros, provisionamentos e comandos sensíveis devem avaliar `Idempotency-Key` e persistência do resultado para evitar duplicidade por retry.
