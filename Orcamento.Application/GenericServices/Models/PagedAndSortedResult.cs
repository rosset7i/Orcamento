using Microsoft.EntityFrameworkCore;

namespace Orcamento.Application.GenericServices.Models;

public class PagedAndSortedResult<TEntity>
{
    public int TotalPages { get; }
    public int CurrentPage { get; }
    public List<TEntity> Items { get; }
    
    private PagedAndSortedResult(int totalPages, int page, List<TEntity> items)
    {
        TotalPages = totalPages;
        CurrentPage = page;
        Items = items;
    }
    
    public static async Task<PagedAndSortedResult<TEntity>> From(
        PagedAndSortedRequest input, 
        IQueryable<TEntity> entities)
    {
        var totalPages = (int)Math.Ceiling((double) await entities.CountAsync() / input.PageSize);

        var pagedResult = await entities
            .Skip((input.PageNumber - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();
        
        return new PagedAndSortedResult<TEntity>(
            totalPages,
            input.PageNumber,
            pagedResult);
    }
}