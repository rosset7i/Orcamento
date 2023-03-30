namespace Orcamento.Application.Produtos.Dtos;

public class CreateProdutoInput
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public Guid IdFornecedor { get; set; }
}