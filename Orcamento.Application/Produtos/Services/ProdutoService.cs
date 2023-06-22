using ErrorOr;
using Orcamento.Application.GenericServices.Models;
using Orcamento.Application.Produtos.Dtos;
using Orcamento.Domain.Common.Errors;
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
    
    public async Task<ErrorOr<PagedAndSortedResult<ProdutoOutput>>> GetAllProdutos(PagedAndSortedRequest input)
    {
        var result = _context.Produto
            .Select(produto => ProdutoOutput.From(produto));

        return await PagedAndSortedResult<ProdutoOutput>.From(input, result);
    }

    public async Task<ErrorOr<ProdutoOutput>> GetProduto(Guid idProduto)
    {
        var produto = await _context.Produto.FindAsync(idProduto);

        if (produto is null)
            return Errors.Common.NotFound;

        return ProdutoOutput.From(produto);
    }

    public async Task<ErrorOr<ValueTask>> CreateProduto(CreateProdutoInput createProdutoInput)
    {
        var novoProduto = new Produto(
            Guid.NewGuid(),
            createProdutoInput.Nome,
            createProdutoInput.Marca,
            createProdutoInput.Descricao);

        await _context.Produto.AddAsync(novoProduto);
        await _context.SaveChangesAsync();

        return ValueTask.CompletedTask;
    }

    public async Task<ErrorOr<ValueTask>> UpdateProduto(Guid idProduto, UpdateProdutoInput updateProdutoInput)
    {
        var produto = await _context.Produto.FindAsync(idProduto);

        if (produto is null)
            return Errors.Common.NotFound;
        
        produto.Nome = updateProdutoInput.Nome;
        produto.Marca = updateProdutoInput.Marca;
        produto.Descricao = updateProdutoInput.Descricao;

        _context.Produto.Update(produto);
        await _context.SaveChangesAsync();

        return ValueTask.CompletedTask;
    }
    
    public async Task<ErrorOr<ValueTask>> DeleteProduto(Guid idProduto)
    {
        var produto = await _context.Produto.FindAsync(idProduto);

        if (produto is null)
            return Errors.Common.NotFound;

        _context.Produto.Remove(produto);
        await _context.SaveChangesAsync();

        return ValueTask.CompletedTask;
    }
}