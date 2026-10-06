// Blueprint de função: o trigger apenas adapta a mensagem e chama Application.
// O SDK do Dataverse permanece na Infraestrutura.

namespace Empresa.Modelo.Functions.Functions;

public sealed class ProcessarIntegracaoDynamics
{
    // [Function("ProcessarIntegracaoDynamics")]
    // public async Task ExecutarAsync([ServiceBusTrigger("fila", Connection = "ServiceBus")] string mensagem, CancellationToken ct)
    // {
    //     await _casoDeUso.ExecutarAsync(mensagem, ct);
    // }
}
