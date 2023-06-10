using Microsoft.EntityFrameworkCore;
using Orcamento.Application.GenericServices;
using Orcamento.Application.Orcamentos.Dtos;
using Orcamento.Application.Orcamentos.Enums;
using Orcamento.Infra.AppDbContext;

namespace Orcamento.Application.Orcamentos.Services;

public class OrcamentoService : IOrcamentoService
{
    private readonly OrcamentoDbContext _context;
    private readonly IDateTimeProviderService _dateTimeProvider;

    public OrcamentoService(OrcamentoDbContext context, IDateTimeProviderService dateTimeProvider)
    {
        _context = context;
        _dateTimeProvider = dateTimeProvider;
    }
    
    public async Task<List<OrcamentoOutput>> GetAllOrcamento()
    {
        return await _context.Orcamento
            .Select(orcamento => OrcamentoOutput.From(orcamento))
            .ToListAsync();
    }
    
    public async Task<OrcamentoOutput> GetOrcamento(Guid idOrcamento)
    {
        var orcamento = await _context.Orcamento.FindAsync(idOrcamento);

        if (orcamento is null)
        {
            return null;
        }

        return OrcamentoOutput.From(orcamento);;
    }

    public async Task<OrcamentoResult> CreateOrcamento(CreateOrcamentoInput createOrcamentoInput)
    {
        var novoOrcamento = new Domain.Entities.OrcamentoEntity(
            Guid.NewGuid(), 
            createOrcamentoInput.Nome,
            _dateTimeProvider.UtcNow,
            createOrcamentoInput.FornecedorId);

        await _context.Orcamento.AddAsync(novoOrcamento);
        var itensSalvos = await _context.SaveChangesAsync();

        return itensSalvos > 0 ? OrcamentoResult.Ok : OrcamentoResult.Erro;
    }

    public async Task<OrcamentoResult> UpdateOrcamento(Guid idOrcamento, UpdateOrcamentoInput updateOrcamentoInput)
    {
        var orcamento = await _context.Orcamento.FindAsync(idOrcamento);

        if (orcamento is null)
        {
            return OrcamentoResult.Erro;
        }
        
        orcamento.Nome = updateOrcamentoInput.Nome;
        orcamento.DataDeCriacao = updateOrcamentoInput.Data;
        orcamento.PrecoTotal = updateOrcamentoInput.PrecoTotal;
        orcamento.ProdutoOrcamento = updateOrcamentoInput.ProdutoOrcamento;

        _context.Orcamento.Update(orcamento);
         await _context.SaveChangesAsync();

         return OrcamentoResult.Ok;
    }
    
    public async Task<OrcamentoResult> DeleteOrcamento(Guid idOrcamento)
    {
        var orcamento = await _context.Orcamento.FindAsync(idOrcamento);

        if (orcamento is null)
        {
            return OrcamentoResult.Erro;
        }

        _context.Orcamento.Remove(orcamento);
        await _context.SaveChangesAsync();

        return OrcamentoResult.Ok;
    }
    
}