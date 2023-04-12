using Orcamento.Application.Produtos.Dtos;
using Orcamento.Application.Produtos.Enums;

namespace Orcamento.Application.Produtos.Services;

public interface IProdutoService
{
    Task<List<ProdutoOutput>> GetAllProdutos(Guid idFornecedor);
    Task<ProdutoOutput> GetProduto(Guid idProduto);
    Task<ProdutoResult> CreateProduto(CreateProdutoInput createProdutoInput);
    Task<ProdutoResult> UpdateProduto(Guid idProduto, UpdateProdutoInput updateProdutoInput);
    Task<ProdutoResult> DeleteProduto(Guid idProduto);
}