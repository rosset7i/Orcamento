namespace Orcamento.Application.GenericServices.Models;

public class PagedAndSortedRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; } = null;
}