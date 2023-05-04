using Orcamento.Domain.Entities;
using Orcamento.Infra.AppDbContext;

namespace Orcamento.Application.Orcamentos.Services;

public class RevisaoOrcamentoService
{
    private readonly OrcamentoDbContext _orcamentoDbContext;

    public RevisaoOrcamentoService(OrcamentoDbContext orcamentoDbContext)
    {
        _orcamentoDbContext = orcamentoDbContext;
    }

    public async Task CompareOrcamentos(List<Guid> orcamentosIds)
    {
        var orcamentosToCompare = await GetOrcamentoList(orcamentosIds);

        var produtosFromOrcamento = GetProdutoListForOrcamento(orcamentosToCompare);

        var sortedList = new List<ProdutoOrcamento>();
        
        foreach (var produtosList in produtosFromOrcamento)
        {
            foreach (var produto in produtosList)
            {
                if (produto.IdProduto.Equals())
                {
                    
                }
            }
        }
        
        


    }

    public async Task<List<Domain.Entities.Orcamento>> GetOrcamentoList(List<Guid> orcamentosIds)
    {
        var orcamentos = new List<Domain.Entities.Orcamento>();

        foreach (var id in orcamentosIds)
        {
            var orcamento = await _orcamentoDbContext.Orcamento.FindAsync(id);
            orcamentos.Add(orcamento);
        }

        return orcamentos;
    }
    
    public List<List<ProdutoOrcamento>> GetProdutoListForOrcamento(List<Domain.Entities.Orcamento> orcamentos)
    {
        var produtosFromOrcamento = new List<List<ProdutoOrcamento>>();

        foreach (var orcamento in orcamentos)
        {
            var produtos = orcamento.ProdutoOrcamento;
            
            
            produtosFromOrcamento.Add(produtos);
        }

        return produtosFromOrcamento;
    }
    
    
}