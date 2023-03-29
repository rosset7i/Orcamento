using Microsoft.EntityFrameworkCore;
using Orcamento.Application.Orcamento.Dtos;
using Orcamento.Domain.Entities;
using Orcamento.Infra.AppDbContext;

namespace Orcamento.Application.Orcamento.Services;

public class ProdutoService
{
    private readonly OrcamentoDbContext _context;

    public ProdutoService(OrcamentoDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProdutoOutput>> GetAllProduto(Guid idFornecedor)
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

    public async Task<Produto> CreateProduto(CreateProdutoInput createProdutoInput)
    {
        var novoProduto = new Produto(
            id: new Guid(),
            nome: createProdutoInput.Nome,
            descricao: createProdutoInput.Descricao,
            preco: createProdutoInput.Preco,
            idFornecedor: createProdutoInput.IdFornecedor
        );

        await _context.Produto.AddAsync(novoProduto);
        await _context.SaveChangesAsync();

        return novoProduto;
    }

    public async Task<Produto> UpdateProduto(Guid idProduto, UpdateProdutoInput updateProdutoInput)
    {
        var produto = await _context.Produto.FindAsync(idProduto);

        if (produto is null)
        {
            return null;
        }
        
        produto.Nome = updateProdutoInput.Nome;
        produto.Descricao = updateProdutoInput.Descricao;
        produto.Preco = updateProdutoInput.Preco;

        _context.Produto.Update(produto);
         await _context.SaveChangesAsync();

         return produto;
    }
    
    public async Task<Produto> DeleteProduto(Guid idProduto)
    {
        var produto = await _context.Produto.FindAsync(idProduto);

        if (produto is null)
        {
            return null;
        }

        _context.Produto.Remove(produto);
        await _context.SaveChangesAsync();

        return produto;
    }
}