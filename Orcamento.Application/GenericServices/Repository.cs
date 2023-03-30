using Microsoft.EntityFrameworkCore;
using Orcamento.Infra.AppDbContext;

namespace Orcamento.Application.GenericServices;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly OrcamentoDbContext _context;

    public Repository(OrcamentoDbContext context)
    {
        _context = context;
    }

    public async Task ToListAsync()
    {
        await _context.Set<T>().ToListAsync();
    }
    
    public async Task FindAsync(Guid id)
    {
        await _context.Set<T>().FindAsync(id);
    }
    
    public async Task AddAsync(T t)
    {
        await _context.Set<T>().AddAsync(t);
    }
    
    public void Update(T t)
    {
        _context.Set<T>().Update(t);
    }
    
    public void Remove(T t)
    {
        _context.Set<T>().Remove(t);
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}