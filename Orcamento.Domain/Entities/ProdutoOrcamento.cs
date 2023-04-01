using System.ComponentModel.DataAnnotations.Schema;

namespace Orcamento.Domain.Entities;

public class ProdutoOrcamento
{
    public Guid Id { get; set; }
    public double Quantidade { get; set; }

    [ForeignKey("Produto")]
    public Guid IdProduto { get; set; }
    public Produto Produto { get; set; }
    
    [ForeignKey("Orcamento")]
    public Guid IdOrcamento { get; set; }
    public Orcamento Orcamento { get; set; }

    public ProdutoOrcamento()
    {
        
    }
    
    public ProdutoOrcamento(Guid id, double quantidade, Guid idProduto, Guid idOrcamento)
    {
        Id = id;
        Quantidade = quantidade;
        IdProduto = idProduto;
        IdOrcamento = idOrcamento;
    }
}