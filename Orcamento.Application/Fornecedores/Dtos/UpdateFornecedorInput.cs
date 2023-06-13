namespace Orcamento.Application.Fornecedores.Dtos;

public record UpdateFornecedorInput(
    string Nome,
    string Endereco,
    string Telefone);