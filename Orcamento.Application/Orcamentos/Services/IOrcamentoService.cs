using Orcamento.Application.Orcamentos.Dtos;
using Orcamento.Application.Orcamentos.Enums;

namespace Orcamento.Application.Orcamentos.Services;

public interface IOrcamentoService
{
    Task<List<OrcamentoOutput>> GetAllOrcamento();
    Task<OrcamentoOutput> GetOrcamento(Guid idOrcamento);
    Task<OperationResult> CreateOrcamento(CreateOrcamentoInput createOrcamentoInput);
    Task<OperationResult> UpdateOrcamento(Guid idOrcamento, UpdateOrcamentoInput updateOrcamentoInput);
    Task<OperationResult> DeleteOrcamento(Guid idOrcamento);
}