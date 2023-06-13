using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.ErrorHandling;
using Orcamento.Application.Produtos.Dtos;
using Orcamento.Application.Produtos.Services;

namespace Orcamento.Application.Produtos.Controllers;

[Route("api/v1/produtos")]
public class ProdutosController : ApiController
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
        var produtoOutput = await _produtoService.GetProduto(idProduto);

        return await produtoOutput.MatchAsync<>(
            result => Ok(result),
            errors => Problem(errors));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduto([FromBody]CreateProdutoInput createProdutoInput)
    {
        var produtoResult = await _produtoService.CreateProduto(createProdutoInput);

        return await produtoResult.MatchAsync<>(
            result => NoContent(),
            errors => Problem(errors));
    }
    
    [HttpPut("{idProduto:guid}")]
    public async Task<IActionResult> UpdateProduto([FromRoute]Guid idProduto, [FromBody]UpdateProdutoInput updateProdutoInput)
    {
        var produtoResult = await _produtoService.UpdateProduto(idProduto, updateProdutoInput);

        return await produtoResult.MatchAsync<>(
            result => NoContent(),
            errors => Problem(errors));
    }
    
    [HttpDelete("{idProduto:guid}")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idProduto)
    {
        var produtoResult = await _produtoService.DeleteProduto(idProduto);

        return await produtoResult.MatchAsync<>(
            result => NoContent(),
            errors => Problem(errors));
    }
}