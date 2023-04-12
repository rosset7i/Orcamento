using Orcamento.Application.Orcamentos.Dtos;
using Orcamento.Application.Orcamentos.Enums;

namespace Orcamento.Application.Orcamentos.Services;

public interface IOrcamentoService
{
    Task<List<OrcamentoOutput>> GetAllOrcamento();
    Task<OrcamentoOutput> GetOrcamento(Guid idOrcamento);
    Task<OrcamentoResult> CreateOrcamento(CreateOrcamentoInput createOrcamentoInput);
    Task<OrcamentoResult> UpdateOrcamento(Guid idOrcamento, UpdateOrcamentoInput updateOrcamentoInput);
    Task<OrcamentoResult> DeleteOrcamento(Guid idOrcamento);
}