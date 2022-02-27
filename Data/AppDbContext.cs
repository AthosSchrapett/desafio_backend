using desafio_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace desafio_backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Pagamento> Pagamento { get; set; }
    public DbSet<Troco> Troco { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Pagamento>()
            .Property(p => p.ValorTotal).IsRequired();
        builder.Entity<Pagamento>()
            .Property(p => p.ValorPago).IsRequired();

        builder.Entity<Troco>()
            .Property(p => p.ValorTroco).IsRequired();
    }

}
