using System.ComponentModel.DataAnnotations.Schema;

namespace Orcamento.Domain.Entities;

public class Orcamento
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    public double PrecoTotal { get; set; }
    
    [ForeignKey("Fornecedor")]
    public Guid FornecedorId { get; set; }
    public Fornecedor Fornecedor { get; set; }

    public List<ProdutoOrcamento> ProdutoOrcamento { get; set; }

    public Orcamento()
    {
        
    }    

    public Orcamento(Guid id, string nome, DateTime data, double precoTotal, Guid fornecedorId, List<ProdutoOrcamento> produtoOrcamento)
    {
        Id = id;
        Nome = nome;
        Data = data;
        PrecoTotal = precoTotal;
        FornecedorId = fornecedorId;
        ProdutoOrcamento = produtoOrcamento;
    }
}