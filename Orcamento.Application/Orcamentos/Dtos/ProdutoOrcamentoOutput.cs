using Orcamento.Domain.Entities;

namespace Orcamento.Application.Orcamentos.Dtos;

public record ProdutoOrcamentoOutput
{
    private Guid Id { get; }
    private string Nome { get; }
    private string Marca { get; }
    private double PrecoUnitario { get; }
    private double PrecoTotal { get; }

    private ProdutoOrcamentoOutput(
        Guid id,
        string nome, 
        string marca,
        double precoUnitario,
        double precoTotal)
    {
        Id = id;
        Nome = nome;
        Marca = marca;
        PrecoUnitario = precoUnitario;
        PrecoTotal = precoTotal;
    }

    public static ProdutoOrcamentoOutput From(ProdutoOrcamento produtoOrcamento)
    {
        return new ProdutoOrcamentoOutput(
            produtoOrcamento.Id,
            produtoOrcamento.Produto.Nome,
            produtoOrcamento.Produto.Marca,
            produtoOrcamento.PrecoUnitario,
            produtoOrcamento.PrecoTotal);
    }
    
    public static List<ProdutoOrcamentoOutput> From(List<ProdutoOrcamento> produtoOrcamentos)
    {
        return produtoOrcamentos
            .Select(produto => From(produto))
            .ToList();
    }
    
}