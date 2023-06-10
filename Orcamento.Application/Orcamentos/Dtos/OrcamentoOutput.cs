using Orcamento.Domain.Entities;

namespace Orcamento.Application.Orcamentos.Dtos;

public class OrcamentoOutput
{
    private Guid Id { get; }
    private string Nome { get; }
    private DateTime DataDeCriacao { get; }
    private double PrecoTotal { get; }
    private List<ProdutoOrcamentoOutput> ProdutoOrcamentoOutput { get; }

    private OrcamentoOutput(
        Guid id,
        string nome,
        DateTime dataDeCriacao,
        double precoTotal,
        List<ProdutoOrcamentoOutput> produtoOrcamentoOutputs)
    {
        Id = id;
        Nome = nome;
        DataDeCriacao = dataDeCriacao;
        PrecoTotal = precoTotal;
        ProdutoOrcamentoOutput = produtoOrcamentoOutputs;
    }
    
    public static OrcamentoOutput From(OrcamentoEntity orcamento)
    {
        return new OrcamentoOutput(
            orcamento.Id,
            orcamento.Nome,
            orcamento.DataDeCriacao,
            orcamento.PrecoTotal,
            Dtos.ProdutoOrcamentoOutput.From(orcamento.ProdutoOrcamento)
        );
    }
}