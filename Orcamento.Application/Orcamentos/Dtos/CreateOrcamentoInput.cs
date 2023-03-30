using Orcamento.Domain.Entities;

namespace Orcamento.Application.Orcamentos.Dtos;

public class CreateOrcamentoInput
{
    public string Nome { get; set; }
    public double PrecoTotal { get; set; }
    public Guid FornecedorId { get; set; }
    public List<ProdutoOrcamento> ProdutoOrcamento { get; set; }
}