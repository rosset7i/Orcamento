using Orcamento.Application.Produtos.Dtos;
using Orcamento.Application.Produtos.Enums;

namespace Orcamento.Application.Produtos.Services;

public interface IProdutoService
{
    Task<List<ProdutoOutput>> GetAllProdutos(Guid idFornecedor);
    Task<ProdutoOutput> GetProduto(Guid idProduto);
    Task<OperationResult> CreateProduto(CreateProdutoInput createProdutoInput);
    Task<OperationResult> UpdateProduto(Guid idProduto, UpdateProdutoInput updateProdutoInput);
    Task<OperationResult> DeleteProduto(Guid idProduto);
}