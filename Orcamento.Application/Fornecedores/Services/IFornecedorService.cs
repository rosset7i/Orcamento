using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Application.Fornecedores.Enums;

namespace Orcamento.Application.Fornecedores.Services;

public interface IFornecedorService
{
    Task<List<FornecedorOutput>> GetAllFornecedores();
    Task<FornecedorOutput> GetFornecedor(Guid idFornecedor);
    Task<FornecedorResult> CreateFornecedor(CreateFornecedorInput createFornecedorInput);
    Task<FornecedorResult> UpdateFornecedor(Guid idFornecedor, UpdateFornecedorInput updateFornecedorInput);
    Task<FornecedorResult> DeleteFornecedor(Guid idFornecedor);
}