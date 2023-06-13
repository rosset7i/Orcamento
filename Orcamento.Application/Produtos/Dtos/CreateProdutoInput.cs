namespace Orcamento.Application.Produtos.Dtos;

public record CreateProdutoInput(
    string Nome,
    string Marca,
    string Descricao);