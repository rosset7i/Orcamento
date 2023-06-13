using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Domain.Common.Errors;
using Orcamento.Domain.Entities;
using Orcamento.Infra.AppDbContext;

namespace Orcamento.Application.Fornecedores.Services;

public class FornecedorService : IFornecedorService
{
    private readonly OrcamentoDbContext _context;

    public FornecedorService(OrcamentoDbContext context)
    {
        _context = context;
    }
    
    public async Task<ErrorOr<List<FornecedorOutput>>> GetAllFornecedores()
    {
        return await _context.Fornecedor
            .Select(fornecedor => FornecedorOutput.From(fornecedor))
            .ToListAsync();
    }
    
    public async Task<ErrorOr<FornecedorOutput>> GetFornecedor(Guid idFornecedor)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(idFornecedor);

        if (fornecedor is null)
        {
            return Errors.Common.NotFound;
        }

        return FornecedorOutput.From(fornecedor);
    }

    public async Task<ErrorOr<ValueTask>> CreateFornecedor(CreateFornecedorInput createFornecedorInput)
    {
        var novoFornecedor = new Fornecedor(
            Guid.NewGuid(),
            createFornecedorInput.Nome,
            createFornecedorInput.Endereco,
            createFornecedorInput.Telefone);

        await _context.Fornecedor.AddAsync(novoFornecedor);
        var itensSalvos = await _context.SaveChangesAsync();

        return itensSalvos > 0 ? ValueTask.CompletedTask : Errors.Common.PersistEntityError;
    }

    public async Task<ErrorOr<ValueTask>> UpdateFornecedor(Guid idFornecedor, UpdateFornecedorInput updateFornecedorInput)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(idFornecedor);

        if (fornecedor is null)
        {
            return Errors.Common.NotFound;
        }
        
        fornecedor.Nome = updateFornecedorInput.Nome;
        fornecedor.Endereco = updateFornecedorInput.Endereco;
        fornecedor.Telefone = updateFornecedorInput.Telefone;

        _context.Fornecedor.Update(fornecedor);
        var itensSalvos = await _context.SaveChangesAsync();

        return itensSalvos > 0 ? ValueTask.CompletedTask : Errors.Common.PersistEntityError;
    }
    
    public async Task<ErrorOr<ValueTask>> DeleteFornecedor(Guid idFornecedor)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(idFornecedor);

        if (fornecedor is null)
        {
            return Errors.Common.NotFound;
        }

        _context.Fornecedor.Remove(fornecedor);
        var itensSalvos = await _context.SaveChangesAsync();

        return itensSalvos > 0 ? ValueTask.CompletedTask : Errors.Common.PersistEntityError;
    }
}