using Microsoft.EntityFrameworkCore;
using Orcamento.Domain.Entities;

namespace Orcamento.Infra.AppDbContext;

public class TemplateDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    //TODO rename the dbContext
    public TemplateDbContext(DbContextOptions option) : base(option)
    {
        
    }
    
}