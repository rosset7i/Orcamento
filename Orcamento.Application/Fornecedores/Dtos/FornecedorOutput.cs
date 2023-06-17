using Orcamento.Domain.Entities;

namespace Orcamento.Application.Fornecedores.Dtos;

public class FornecedorOutput
{
    public Guid Id { get; }
    public string Nome { get; }
    public string Endereco { get; }
    public string Telefone { get; }

    public FornecedorOutput()
    {
        
    }

    private FornecedorOutput(
        Guid id,
        string nome,
        string endereco,
        string telefone)
    {
        Id = id;
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
    }

    public static FornecedorOutput From(Fornecedor fornecedor)
    {
        return new FornecedorOutput(
            fornecedor.Id,
            fornecedor.Nome, 
            fornecedor.Endereco, 
            fornecedor.Telefone);
    }
    
    public static List<FornecedorOutput> From(List<Fornecedor> fornecedores)
    {
        return fornecedores
            .Select(fornecedor => From(fornecedor))
            .ToList();
    }
}