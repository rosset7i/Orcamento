using ErrorOr;
using Orcamento.Application.GenericServices.Models;
using Orcamento.Application.Orcamentos.Dtos;

namespace Orcamento.Application.Orcamentos.Services;

public interface IOrcamentoService
{
    Task<ErrorOr<PagedAndSortedResult<OrcamentoOutput>>> GetAllOrcamento(PagedAndSortedRequest input);
    Task<ErrorOr<OrcamentoOutput>> GetOrcamento(Guid idOrcamento);
    Task<ErrorOr<ValueTask>> CreateOrcamento(CreateOrcamentoInput createOrcamentoInput);
    Task<ErrorOr<ValueTask>> UpdateOrcamento(Guid idOrcamento, UpdateOrcamentoInput updateOrcamentoInput);
    Task<ErrorOr<ValueTask>> DeleteOrcamento(Guid idOrcamento);
}