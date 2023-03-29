namespace Orcamento.Application.Orcamento.Dtos;

public class UpdateProdutoInput
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }

    public UpdateProdutoInput(string nome, string descricao, double preco)
    {
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }
}