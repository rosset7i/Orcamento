using Orcamento.Domain.Entities;

namespace Orcamento.Application.Orcamentos.Dtos;

public class UpdateOrcamentoInput
{
    public string Nome { get; set; }
    public double PrecoTotal { get; set; }
    public DateTime Data { get; set; }
    public List<ProdutoOrcamento> ProdutoOrcamento { get; set; }
}