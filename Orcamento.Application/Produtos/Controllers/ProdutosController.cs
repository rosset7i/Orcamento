using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Application.Produtos.Dtos;
using Orcamento.Application.Produtos.Enums;
using Orcamento.Application.Produtos.Services;

namespace Orcamento.Application.Produtos.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutosController : Controller
{
    private readonly ProdutoService _produtoService;

    public ProdutosController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet("{id}/all")]
    public async Task<IActionResult> GetAllProdutos([FromRoute]Guid idFornecedor)
    {
        var produtos = await _produtoService.GetAllProdutos(idFornecedor);

        return Ok(produtos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduto([FromRoute]Guid idProduto)
    {
        var produto = await _produtoService.GetProduto(idProduto);

        return produto is not null ? Ok(produto) : NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduto([FromBody]CreateProdutoInput createProdutoInput)
    {
        var produto = await _produtoService.CreateProduto(createProdutoInput);

        return produto == ProdutoResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto([FromRoute]Guid idProduto, [FromBody]UpdateProdutoInput updateProdutoInput)
    {
        var produto = await _produtoService.UpdateProduto(idProduto, updateProdutoInput);

        return produto == ProdutoResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idProduto)
    {
        var produto = await _produtoService.DeleteProduto(idProduto);

        return produto == ProdutoResult.Ok ? Ok() : BadRequest();
    }
}