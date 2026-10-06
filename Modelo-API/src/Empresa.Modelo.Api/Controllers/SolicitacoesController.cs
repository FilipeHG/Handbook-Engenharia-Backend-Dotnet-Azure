using Empresa.Modelo.Aplicacao.Solicitacoes;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Modelo.Api.Controllers;

[ApiController]
[Route("api/v1/solicitacoes")]
public sealed class SolicitacoesController(CriarSolicitacaoServico criar) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CriarAsync(
        [FromBody] CriarSolicitacaoRequest request,
        CancellationToken cancellationToken)
    {
        var id = await criar.ExecutarAsync(request.Titulo, cancellationToken);
        return Created($"/api/v1/solicitacoes/{id}", new { id });
    }
}

public sealed record CriarSolicitacaoRequest(string Titulo);
