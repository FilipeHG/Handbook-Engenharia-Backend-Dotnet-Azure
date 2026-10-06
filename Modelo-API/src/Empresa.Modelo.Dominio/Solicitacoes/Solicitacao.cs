namespace Empresa.Modelo.Dominio.Solicitacoes;

public sealed class Solicitacao
{
    private Solicitacao() { }

    private Solicitacao(Guid id, string titulo, DateTimeOffset criadaEm)
    {
        Id = id;
        Titulo = titulo;
        CriadaEm = criadaEm;
    }

    public Guid Id { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public DateTimeOffset CriadaEm { get; private set; }

    public static Solicitacao Criar(string titulo, DateTimeOffset agora)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("O título é obrigatório.", nameof(titulo));

        return new Solicitacao(Guid.NewGuid(), titulo.Trim(), agora);
    }
}
