using System.ComponentModel.DataAnnotations.Schema;

namespace Orcamento.Domain.Entities;

public class ProdutoOrcamento
{
    public Guid Id { get; set; }
    public double Quantidade { get; set; }
    public double PrecoUnitario { get; set; } 
    public double PrecoTotal { get; set; }

    [ForeignKey("Produto")]
    public Guid IdProduto { get; set; }
    public Produto Produto { get; set; }
    
    [ForeignKey("Orcamento")]
    public Guid IdOrcamento { get; set; }
    public OrcamentoEntity OrcamentoEntity { get; set; }

    public ProdutoOrcamento(
        Guid id, 
        double quantidade, 
        double precoUnitario, 
        Guid idProduto, 
        Guid idOrcamento)
    {
        Id = id;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
        IdProduto = idProduto;
        IdOrcamento = idOrcamento;
        PrecoTotal = CalculateTotalPrice();
    }

    private double CalculateTotalPrice()
    {
        return PrecoUnitario * Quantidade;;
    }
    
}