namespace Orcamento.Application.Orcamento.Dtos;

public class CreateProdutoInput
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public Guid IdFornecedor { get; set; }

    public CreateProdutoInput(string nome, string descricao, double preco, Guid idFornecedor)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        IdFornecedor = idFornecedor;
    }
}