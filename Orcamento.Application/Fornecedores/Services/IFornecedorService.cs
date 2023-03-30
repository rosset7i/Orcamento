using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Application.Fornecedores.Enums;

namespace Orcamento.Application.Fornecedores.Services;

public interface IFornecedorService
{
    Task<List<FornecedorOutput>> GetAllFornecedores();
    Task<FornecedorOutput> GetFornecedor(Guid idFornecedor);
    Task<OperationResult> CreateFornecedor(CreateFornecedorInput createFornecedorInput);
    Task<OperationResult> UpdateFornecedor(Guid idFornecedor, UpdateFornecedorInput updateFornecedorInput);
    Task<OperationResult> DeleteFornecedor(Guid idFornecedor);
}