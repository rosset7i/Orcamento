using ErrorOr;
using Orcamento.Application.GenericServices.Models;
using Orcamento.Application.Produtos.Dtos;

namespace Orcamento.Application.Produtos.Services;

public interface IProdutoService
{
    Task<ErrorOr<PagedAndSortedResult<ProdutoOutput>>> GetAllProdutos(PagedAndSortedRequest input);
    Task<ErrorOr<ProdutoOutput>> GetProduto(Guid idProduto);
    Task<ErrorOr<ValueTask>> CreateProduto(CreateProdutoInput createProdutoInput);
    Task<ErrorOr<ValueTask>> UpdateProduto(Guid idProduto, UpdateProdutoInput updateProdutoInput);
    Task<ErrorOr<ValueTask>> DeleteProduto(Guid idProduto);
}