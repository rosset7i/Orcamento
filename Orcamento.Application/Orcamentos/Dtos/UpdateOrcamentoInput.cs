using Orcamento.Domain.Entities;

namespace Orcamento.Application.Orcamentos.Dtos;

public class UpdateOrcamentoInput
{
    public string Nome { get; }
    public double PrecoTotal { get; }
    public List<ProdutoOrcamento> ProdutoOrcamento { get; }
    
    public UpdateOrcamentoInput(
        string nome,
        double precoTotal,
        List<ProdutoOrcamento> produtoOrcamento)
    {
        Nome = nome;
        PrecoTotal = precoTotal;
        ProdutoOrcamento = produtoOrcamento;
    }

    public void Update(OrcamentoEntity orcamento)
    {
        orcamento.Nome = Nome;
        orcamento.PrecoTotal = PrecoTotal;
        orcamento.ProdutoOrcamento = ProdutoOrcamento;
    }
}
    
    