# Escopo E2E do modelo

Testar pelo menos:

1. request HTTP válido atravessa controller -> Application -> repositório;
2. request inválido retorna Problem Details;
3. autenticação/authorization policy;
4. health endpoints;
5. integração Dataverse em ambiente/simulador controlado quando fizer parte do caminho crítico;
6. Function/Worker: mensagem -> caso de uso -> efeito observável/idempotência.
