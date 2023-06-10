using Microsoft.EntityFrameworkCore;
using Orcamento.Domain.Entities;

namespace Orcamento.Infra.AppDbContext;

public class OrcamentoDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<OrcamentoEntity> Orcamento { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<Fornecedor> Fornecedor { get; set; }
    public DbSet<ProdutoOrcamento> ProdutoOrcamento { get; set; }

    public OrcamentoDbContext(DbContextOptions option) : base(option)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToLower());

            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName().ToLower());
            }
        }
    }
}