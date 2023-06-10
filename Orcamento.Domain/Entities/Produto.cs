namespace Orcamento.Domain.Entities;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Marca { get; set; }
    public string Descricao { get; set; }

    public List<ProdutoOrcamento> ProdutoOrcamento { get; set; }
    
    public Produto(Guid id, string nome, string descricao, string marca)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Marca = marca;
    }
}