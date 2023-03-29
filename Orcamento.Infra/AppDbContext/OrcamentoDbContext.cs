using Microsoft.EntityFrameworkCore;
using Orcamento.Domain.Entities;

namespace Orcamento.Infra.AppDbContext;

public class OrcamentoDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Domain.Entities.Orcamento> Orcamento { get; set; }
    public DbSet<Produto> Produto { get; set; }
    public DbSet<Fornecedor> Fornecedor { get; set; }
    public DbSet<ProdutoOrcamento> ProdutoOrcamento { get; set; }

    public OrcamentoDbContext(DbContextOptions option) : base(option)
    {
        
    }
    
}