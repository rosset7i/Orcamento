using Orcamento.Domain.Entities;

namespace Orcamento.Application.Produtos.Dtos;

public class UpdateProdutoInput
{
    public string Nome { get; }
    public string Marca { get; }
    public string Descricao { get; }
    
    public UpdateProdutoInput(
        string nome,
        string marca,
        string descricao)
    {
        Nome = nome;
        Marca = marca;
        Descricao = descricao;
    }

    public void Update(Produto produto)
    {
        produto.Nome = Nome;
        produto.Marca = Marca;
        produto.Descricao = Descricao;
    }
}