using System.ComponentModel.DataAnnotations.Schema;

namespace Orcamento.Domain.Entities;

[Table(name:"orcamento")]
public class OrcamentoEntity
{
    public Guid Id { get; set; }
    [Column]
    public string Nome { get; set; }
    public DateTime DataDeCriacao { get; set; }
    public double PrecoTotal { get; set; }
    
    [ForeignKey("Fornecedor")]
    public Guid FornecedorId { get; set; }
    public Fornecedor Fornecedor { get; set; }
    public List<ProdutoOrcamento> ProdutoOrcamento { get; set; }

    public OrcamentoEntity(
        Guid id,
        string nome,
        DateTime dataDeCriacao,
        Guid fornecedorId)
    {
        Id = id;
        Nome = nome;
        DataDeCriacao = dataDeCriacao;
        FornecedorId = fornecedorId;
    }

}