using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Produtos.Dtos;
using Orcamento.Application.Produtos.Enums;
using Orcamento.Application.Produtos.Services;

namespace Orcamento.Application.Produtos.Controllers;

[ApiController]
[Route("api/v1/produtos")]
public class ProdutosController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutosController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProdutos()
    {
        return Ok(await _produtoService.GetAllProdutos());
    }
    
    [HttpGet("{idProduto:guid}")]
    public async Task<IActionResult> GetProduto([FromRoute]Guid idProduto)
    {
        return Ok(await _produtoService.GetProduto(idProduto));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduto([FromBody]CreateProdutoInput createProdutoInput)
    {
        var produto = await _produtoService.CreateProduto(createProdutoInput);

        return produto == ProdutoResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpPut("{idProduto:guid}")]
    public async Task<IActionResult> UpdateProduto([FromRoute]Guid idProduto, [FromBody]UpdateProdutoInput updateProdutoInput)
    {
        var produto = await _produtoService.UpdateProduto(idProduto, updateProdutoInput);

        return produto == ProdutoResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpDelete("{idProduto:guid}")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idProduto)
    {
        var produto = await _produtoService.DeleteProduto(idProduto);

        return produto == ProdutoResult.Ok ? Ok() : BadRequest();
    }
}