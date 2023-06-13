namespace Orcamento.Application.Fornecedores.Dtos;

public record CreateFornecedorInput(
    string Nome,
    string Endereco,
    string Telefone);