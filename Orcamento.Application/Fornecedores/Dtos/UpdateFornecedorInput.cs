using Orcamento.Domain.Entities;

namespace Orcamento.Application.Fornecedores.Dtos;

public class UpdateFornecedorInput
{
    public string Nome { get; }
    public string Endereco { get; }
    public string Telefone { get; }
    
    public UpdateFornecedorInput(
        string nome,
        string endereco,
        string telefone)
    {
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
    }

    public void Update(Fornecedor fornecedor)
    {
        fornecedor.Nome = Nome;
        fornecedor.Endereco = Endereco;
        fornecedor.Telefone = Telefone;
    }
}