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
    
    public async Task<List<ProdutoOutput>> GetAllProdutos(Guid idFornecedor)
    {
        var produtos = await _context.Produto
            .Where(produto => produto.IdFornecedor == idFornecedor)
            .Select(produto => new ProdutoOutput
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
            })
            .ToListAsync();

        return produtos;
    }
    
    public async Task<ProdutoOutput> GetProduto(Guid idProduto)
    {
        var produto = await _context.Produto.FindAsync(idProduto);

        if (produto is null)
        {
            return null;
        }
        
        var produtoOutput = new ProdutoOutput
        {
            Nome = produto.Nome,
            Descricao = produto.Descricao,
            Preco = produto.Preco
        };
            
        return produtoOutput;
    }

    public async Task<ProdutoResult> CreateProduto(CreateProdutoInput createProdutoInput)
    {
        var novoProduto = new Produto(
            id: new Guid(),
            nome: createProdutoInput.Nome,
            descricao: createProdutoInput.Descricao,
            preco: createProdutoInput.Preco,
            idFornecedor: createProdutoInput.IdFornecedor
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
        produto.Descricao = updateProdutoInput.Descricao;
        produto.Preco = updateProdutoInput.Preco;

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