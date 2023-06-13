using ErrorOr;
using Orcamento.Application.Orcamentos.Dtos;

namespace Orcamento.Application.Orcamentos.Services;

public interface IOrcamentoService
{
    Task<ErrorOr<List<OrcamentoOutput>>> GetAllOrcamento();
    Task<ErrorOr<OrcamentoOutput>> GetOrcamento(Guid idOrcamento);
    Task<ErrorOr<ValueTask>> CreateOrcamento(CreateOrcamentoInput createOrcamentoInput);
    Task<ErrorOr<ValueTask>> UpdateOrcamento(Guid idOrcamento, UpdateOrcamentoInput updateOrcamentoInput);
    Task<ErrorOr<ValueTask>> DeleteOrcamento(Guid idOrcamento);
}