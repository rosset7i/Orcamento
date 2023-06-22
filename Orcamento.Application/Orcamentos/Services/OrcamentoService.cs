using ErrorOr;
using Orcamento.Application.GenericServices;
using Orcamento.Application.GenericServices.Models;
using Orcamento.Application.Orcamentos.Dtos;
using Orcamento.Domain.Common.Errors;
using Orcamento.Domain.Entities;
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
    
    public async Task<ErrorOr<PagedAndSortedResult<OrcamentoOutput>>> GetAllOrcamento(PagedAndSortedRequest input)
    {
        var result = _context.Orcamento
            .Select(orcamento => OrcamentoOutput.From(orcamento));

        return await PagedAndSortedResult<OrcamentoOutput>.From(input, result);
    }
    
    public async Task<ErrorOr<OrcamentoOutput>> GetOrcamento(Guid idOrcamento)
    {
        var orcamento = await _context.Orcamento.FindAsync(idOrcamento);

        if (orcamento is null)
            return Errors.Common.NotFound;

        return OrcamentoOutput.From(orcamento);
    }

    public async Task<ErrorOr<ValueTask>> CreateOrcamento(CreateOrcamentoInput createOrcamentoInput)
    {
        var novoOrcamento = new OrcamentoEntity(
            Guid.NewGuid(), 
            createOrcamentoInput.Nome,
            _dateTimeProvider.UtcNow,
            createOrcamentoInput.FornecedorId);

        await _context.Orcamento.AddAsync(novoOrcamento);
        await _context.SaveChangesAsync();

        return ValueTask.CompletedTask;
    }

    public async Task<ErrorOr<ValueTask>> UpdateOrcamento(Guid idOrcamento, UpdateOrcamentoInput updateOrcamentoInput)
    {
        var orcamento = await _context.Orcamento.FindAsync(idOrcamento);
        
        if (orcamento is null)
            return Errors.Common.NotFound;
        
        orcamento.Nome = updateOrcamentoInput.Nome;
        orcamento.PrecoTotal = updateOrcamentoInput.PrecoTotal;
        orcamento.ProdutoOrcamento = updateOrcamentoInput.ProdutoOrcamento;

        _context.Orcamento.Update(orcamento);
        await _context.SaveChangesAsync();

        return ValueTask.CompletedTask;
    }
    
    public async Task<ErrorOr<ValueTask>> DeleteOrcamento(Guid idOrcamento)
    {
        var orcamento = await _context.Orcamento.FindAsync(idOrcamento);

        if (orcamento is null)
            return Errors.Common.NotFound;

        _context.Orcamento.Remove(orcamento);
        await _context.SaveChangesAsync();

        return ValueTask.CompletedTask;
    }
    
}