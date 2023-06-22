using ErrorOr;
using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Application.GenericServices.Models;
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
    
    public async Task<PagedAndSortedResult<FornecedorOutput>> GetAllFornecedores(PagedAndSortedRequest input)
    {
        var result = _context.Fornecedor
            .Select(fornecedor => FornecedorOutput.From(fornecedor));

        return await PagedAndSortedResult<FornecedorOutput>.From(input, result);
    }

    public async Task<ErrorOr<FornecedorOutput>> GetFornecedor(Guid idFornecedor)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(idFornecedor);

        if (fornecedor is null)
            return Errors.Common.NotFound;

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
        await _context.SaveChangesAsync();

        return ValueTask.CompletedTask;
    }

    public async Task<ErrorOr<ValueTask>> UpdateFornecedor(Guid idFornecedor, UpdateFornecedorInput updateFornecedorInput)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(idFornecedor);

        if (fornecedor is null)
            return Errors.Common.NotFound;
        
        updateFornecedorInput.Update(fornecedor);

        _context.Fornecedor.Update(fornecedor);
        await _context.SaveChangesAsync();

        return ValueTask.CompletedTask;
    }
    
    public async Task<ErrorOr<ValueTask>> DeleteFornecedor(Guid idFornecedor)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(idFornecedor);

        if (fornecedor is null)
            return Errors.Common.NotFound;

        _context.Fornecedor.Remove(fornecedor);
        await _context.SaveChangesAsync();

        return ValueTask.CompletedTask;
    }
}