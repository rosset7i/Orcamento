using System.ComponentModel.DataAnnotations.Schema;

namespace Orcamento.Domain.Entities;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    
    [ForeignKey("Fornecedor")]
    public Guid IdFornecedor { get; set; }
    public Fornecedor Fornecedor { get; set; }

    public List<ProdutoOrcamento> ProdutoOrcamento { get; set; }

    public Produto()
    {
        
    }
    
    public Produto(Guid id, string nome, string descricao, double preco, Guid idFornecedor)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        IdFornecedor = idFornecedor;
    }
}