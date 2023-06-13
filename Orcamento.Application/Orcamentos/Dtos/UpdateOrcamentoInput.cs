using Orcamento.Domain.Entities;

namespace Orcamento.Application.Orcamentos.Dtos;

public record UpdateOrcamentoInput(
    string Nome,
    double PrecoTotal,
    List<ProdutoOrcamento> ProdutoOrcamento);