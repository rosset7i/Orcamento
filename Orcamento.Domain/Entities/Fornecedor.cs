namespace Orcamento.Domain.Entities;

public class Fornecedor
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public List<Orcamento> Orcamento { get; set; }

    public Fornecedor()
    {
        
    }
    
    public Fornecedor(Guid id, string nome, string endereco, string telefone)
    {
        Id = id;
        Nome = nome;
        Endereco = endereco;
        Telefone = telefone;
    }
}