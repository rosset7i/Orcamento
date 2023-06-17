using ErrorOr;
using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Application.GenericServices.Models;

namespace Orcamento.Application.Fornecedores.Services;

public interface IFornecedorService
{
    Task<PagedAndSortedResult<FornecedorOutput>> GetAllFornecedores(PagedAndSortedRequest input);
    Task<ErrorOr<FornecedorOutput>> GetFornecedor(Guid idFornecedor);
    Task<ErrorOr<ValueTask>> CreateFornecedor(CreateFornecedorInput createFornecedorInput);
    Task<ErrorOr<ValueTask>> UpdateFornecedor(Guid idFornecedor, UpdateFornecedorInput updateFornecedorInput);
    Task<ErrorOr<ValueTask>> DeleteFornecedor(Guid idFornecedor);
}