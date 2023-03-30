namespace Orcamento.Application.GenericServices;

public interface IRepository<T> where T : class
{
    Task ToListAsync();
    Task FindAsync(Guid id);
    Task AddAsync(T t);
    void Update(T t);
    void Remove(T t);
    Task SaveChangesAsync();
}