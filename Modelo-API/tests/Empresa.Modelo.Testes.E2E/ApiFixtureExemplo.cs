// Requer referência a Microsoft.AspNetCore.Mvc.Testing no projeto E2E.
// Exemplo de base; substituir dependências externas por fixtures/test doubles controlados.

using Microsoft.AspNetCore.Mvc.Testing;

namespace Empresa.Modelo.Testes.E2E;

public sealed class ApiFixtureExemplo : WebApplicationFactory<Program>
{
}
