namespace Orcamento.Application.Produtos.Dtos;

public record UpdateProdutoInput(
    string Nome,
    string Marca,
    string Descricao);