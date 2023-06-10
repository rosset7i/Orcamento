using Orcamento.Domain.Entities;

namespace Orcamento.Application.Produtos.Dtos;

public class ProdutoOutput
{
    private Guid Id { get; }
    private string Nome { get; }
    private string Marca { get; }
    private string Descricao { get; }

    public ProdutoOutput()
    {
        
    }

    private ProdutoOutput(
        Guid id,
        string nome,
        string marca,
        string descricao)
    {
        Id = id;
        Nome = nome;
        Marca = marca;
        Descricao = descricao;
    }

    public static ProdutoOutput From(Produto produto)
    {
        return new ProdutoOutput(
            produto.Id, 
            produto.Nome, 
            produto.Marca, 
            produto.Descricao);
    }

    public static List<ProdutoOutput> From(List<Produto> produtos)
    {
        return produtos
            .Select(produto => From(produto))
            .ToList();
    }
}