using System.ComponentModel.DataAnnotations.Schema;

namespace Orcamento.Domain.Entities;

public class ProdutoOrcamento
{
    public Guid Id { get; set; }
    public double Quantidade { get; set; }
    public double Preco { get; set; } 


    [ForeignKey("Produto")]
    public Guid IdProduto { get; set; }
    public Produto Produto { get; set; }
    
    [ForeignKey("Orcamento")]
    public Guid IdOrcamento { get; set; }
    public Orcamento Orcamento { get; set; }

    public ProdutoOrcamento()
    {
        
    }
    
    public ProdutoOrcamento(Guid id, double quantidade, double preco, Guid idProduto, Guid idOrcamento)
    {
        Id = id;
        Quantidade = quantidade;
        Preco = preco;
        IdProduto = idProduto;
        IdOrcamento = idOrcamento;
    }
    
    public double CalculateTotalPrice()
    {
        var precoTotal = this.Preco * this.Quantidade;

        return precoTotal;
    }
}