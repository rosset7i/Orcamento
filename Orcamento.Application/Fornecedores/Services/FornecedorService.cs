using Microsoft.EntityFrameworkCore;
using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Application.Fornecedores.Enums;
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
    
    public async Task<List<FornecedorOutput>> GetAllFornecedores()
    {
        var produtos = await _context.Fornecedor
            .Select(fornecedor => new FornecedorOutput()
            {
                Nome = fornecedor.Nome,
                Endereco  = fornecedor.Endereco,
                Telefone = fornecedor.Telefone
            })
            .ToListAsync();

        return produtos;
    }
    
    public async Task<FornecedorOutput> GetFornecedor(Guid idFornecedor)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(idFornecedor);

        if (fornecedor is null)
        {
            return null;
        }
        
        var fornecedorOutput = new FornecedorOutput
        {
            Nome = fornecedor.Nome,
            Endereco = fornecedor.Endereco,
            Telefone = fornecedor.Telefone
        };
            
        return fornecedorOutput;
    }

    public async Task<FornecedorResult> CreateFornecedor(CreateFornecedorInput createFornecedorInput)
    {
        var novoFornecedor = new Fornecedor(
            id: new Guid(),
            nome: createFornecedorInput.Nome,
            endereco: createFornecedorInput.Endereco,
            telefone: createFornecedorInput.Telefone
        );

        await _context.Fornecedor.AddAsync(novoFornecedor);
        var itensSalvos = await _context.SaveChangesAsync();

        return itensSalvos > 0 ? FornecedorResult.Ok : FornecedorResult.Erro;
    }

    public async Task<FornecedorResult> UpdateFornecedor(Guid idFornecedor, UpdateFornecedorInput updateFornecedorInput)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(idFornecedor);

        if (fornecedor is null)
        {
            return FornecedorResult.Erro;
        }
        
        fornecedor.Nome = updateFornecedorInput.Nome;
        fornecedor.Endereco = updateFornecedorInput.Endereco;
        fornecedor.Telefone = updateFornecedorInput.Telefone;

        _context.Fornecedor.Update(fornecedor);
         await _context.SaveChangesAsync();

         return FornecedorResult.Ok;
    }
    
    public async Task<FornecedorResult> DeleteFornecedor(Guid idFornecedor)
    {
        var fornecedor = await _context.Fornecedor.FindAsync(idFornecedor);

        if (fornecedor is null)
        {
            return FornecedorResult.Erro;
        }

        _context.Fornecedor.Remove(fornecedor);
        await _context.SaveChangesAsync();

        return FornecedorResult.Ok;
    }
}