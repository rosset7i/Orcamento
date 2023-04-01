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
        var orcamentos = await _context.Orcamento
            .Select(orcamento => new OrcamentoOutput
            {
                Nome = orcamento.Nome,
                Data = orcamento.Data,
                PrecoTotal = orcamento.PrecoTotal,
                ProdutoOrcamento = orcamento.ProdutoOrcamento
            })
            .ToListAsync();

        return orcamentos;
    }
    
    public async Task<OrcamentoOutput> GetOrcamento(Guid idOrcamento)
    {
        var orcamento = await _context.Orcamento.FindAsync(idOrcamento);

        if (orcamento is null)
        {
            return null;
        }
        
        var orcamentoOutput = new OrcamentoOutput
        {
            Nome = orcamento.Nome,
            Data = orcamento.Data,
            PrecoTotal = orcamento.PrecoTotal,
            ProdutoOrcamento = orcamento.ProdutoOrcamento
        };
            
        return orcamentoOutput;
    }

    public async Task<OperationResult> CreateOrcamento(CreateOrcamentoInput createOrcamentoInput)
    {
        var novoOrcamento = new Domain.Entities.Orcamento(
            id: new Guid(),
            nome: createOrcamentoInput.Nome,
            data: _dateTimeProvider.UtcNow,
            precoTotal: createOrcamentoInput.PrecoTotal,
            fornecedorId: createOrcamentoInput.FornecedorId,
            produtoOrcamento: createOrcamentoInput.ProdutoOrcamento
        );

        await _context.Orcamento.AddAsync(novoOrcamento);
        var itensSalvos = await _context.SaveChangesAsync();

        return itensSalvos > 0 ? OperationResult.Ok : OperationResult.Erro;
    }

    public async Task<OperationResult> UpdateOrcamento(Guid idOrcamento, UpdateOrcamentoInput updateOrcamentoInput)
    {
        var orcamento = await _context.Orcamento.FindAsync(idOrcamento);

        if (orcamento is null)
        {
            return OperationResult.Erro;
        }
        
        orcamento.Nome = updateOrcamentoInput.Nome;
        orcamento.Data = updateOrcamentoInput.Data;
        orcamento.PrecoTotal = updateOrcamentoInput.PrecoTotal;
        orcamento.ProdutoOrcamento = updateOrcamentoInput.ProdutoOrcamento;

        _context.Orcamento.Update(orcamento);
         await _context.SaveChangesAsync();

         return OperationResult.Ok;
    }
    
    public async Task<OperationResult> DeleteOrcamento(Guid idOrcamento)
    {
        var orcamento = await _context.Orcamento.FindAsync(idOrcamento);

        if (orcamento is null)
        {
            return OperationResult.Erro;
        }

        _context.Orcamento.Remove(orcamento);
        await _context.SaveChangesAsync();

        return OperationResult.Ok;
    }
    
}