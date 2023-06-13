using ErrorOr;
using Orcamento.Application.Fornecedores.Dtos;

namespace Orcamento.Application.Fornecedores.Services;

public interface IFornecedorService
{
    Task<ErrorOr<List<FornecedorOutput>>> GetAllFornecedores();
    Task<ErrorOr<FornecedorOutput>> GetFornecedor(Guid idFornecedor);
    Task<ErrorOr<ValueTask>> CreateFornecedor(CreateFornecedorInput createFornecedorInput);
    Task<ErrorOr<ValueTask>> UpdateFornecedor(Guid idFornecedor, UpdateFornecedorInput updateFornecedorInput);
    Task<ErrorOr<ValueTask>> DeleteFornecedor(Guid idFornecedor);
}