using Orcamento.Domain.Entities;

namespace Orcamento.Application.Orcamentos.Dtos;

public record CreateOrcamentoInput(
    string Nome,
    double PrecoTotal,
    Guid FornecedorId,
    List<ProdutoOrcamento> ProdutoOrcamento);