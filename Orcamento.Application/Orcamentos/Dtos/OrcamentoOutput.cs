using Orcamento.Domain.Entities;

namespace Orcamento.Application.Orcamentos.Dtos;

public class OrcamentoOutput
{
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    public double PrecoTotal { get; set; }
    //TODO criar dto para ProdutoOrcamento
    public List<ProdutoOrcamento> ProdutoOrcamento { get; set; }
}