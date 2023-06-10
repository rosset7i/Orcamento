using Microsoft.EntityFrameworkCore;
using Orcamento.Application.Produtos.Dtos;
using Orcamento.Application.Produtos.Enums;
using Orcamento.Domain.Entities;
using Orcamento.Infra.AppDbContext;

namespace Orcamento.Application.Produtos.Services;

public class ProdutoService : IProdutoService
{
    private readonly OrcamentoDbContext _context;

    public ProdutoService(OrcamentoDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProdutoOutput>> GetAllProdutos()
    {
        return await _context.Produto
            .Select(produto => ProdutoOutput.From(produto))
            .ToListAsync();
    }

    public async Task<ProdutoOutput> GetProduto(Guid idProduto)
    {
        var produto = await _context.Produto.FindAsync(idProduto);

        if (produto is null)
        {
            return null;
        }

        return ProdutoOutput.From(produto);;
    }

    public async Task<ProdutoResult> CreateProduto(CreateProdutoInput createProdutoInput)
    {
        var novoProduto = new Produto(
            Guid.NewGuid(),
            createProdutoInput.Nome,
            createProdutoInput.Marca,
            createProdutoInput.Descricao
        );

        await _context.Produto.AddAsync(novoProduto);
        var itensSalvos = await _context.SaveChangesAsync();

        return itensSalvos > 0 ? ProdutoResult.Ok : ProdutoResult.Erro;
    }

    public async Task<ProdutoResult> UpdateProduto(Guid idProduto, UpdateProdutoInput updateProdutoInput)
    {
        var produto = await _context.Produto.FindAsync(idProduto);

        if (produto is null)
        {
            return ProdutoResult.Erro;
        }
        
        produto.Nome = updateProdutoInput.Nome;
        produto.Marca = updateProdutoInput.Marca;
        produto.Descricao = updateProdutoInput.Descricao;

        _context.Produto.Update(produto);
         await _context.SaveChangesAsync();

         return ProdutoResult.Ok;
    }
    
    public async Task<ProdutoResult> DeleteProduto(Guid idProduto)
    {
        var produto = await _context.Produto.FindAsync(idProduto);

        if (produto is null)
        {
            return ProdutoResult.Erro;
        }

        _context.Produto.Remove(produto);
        await _context.SaveChangesAsync();

        return ProdutoResult.Ok;
    }
}