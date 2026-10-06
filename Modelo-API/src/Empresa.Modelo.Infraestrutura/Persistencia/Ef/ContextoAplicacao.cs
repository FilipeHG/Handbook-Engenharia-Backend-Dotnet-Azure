using Empresa.Modelo.Dominio.Solicitacoes;
using Microsoft.EntityFrameworkCore;

namespace Empresa.Modelo.Infraestrutura.Persistencia.Ef;

public sealed class ContextoAplicacao(DbContextOptions<ContextoAplicacao> options) : DbContext(options)
{
    public DbSet<Solicitacao> Solicitacoes => Set<Solicitacao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Solicitacao>(e =>
        {
            e.ToTable("Solicitacoes");
            e.HasKey(x => x.Id);
            e.Property(x => x.Titulo).HasMaxLength(200).IsRequired();
            e.Property(x => x.CriadaEm).IsRequired();
        });
    }
}
