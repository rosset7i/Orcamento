using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.ErrorHandling;
using Orcamento.Application.GenericServices.Models;
using Orcamento.Application.Produtos.Dtos;
using Orcamento.Application.Produtos.Services;

namespace Orcamento.Application.Produtos.Controllers;

[Route("api/v1/produtos")]
public class ProdutosController : ApiController
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProdutos([FromQuery]PagedAndSortedRequest input)
    {
        return Ok(await _produtoService.GetAllProdutos(input));
    }
    
    [HttpGet("{idProduto:guid}")]
    public async Task<IActionResult> GetProduto([FromRoute]Guid idProduto)
    {
        var produtoOutput = await _produtoService.GetProduto(idProduto);

        return produtoOutput.Match(
            result => Ok(result),
            errors => Problem(errors));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduto([FromBody]CreateProdutoInput createProdutoInput)
    {
        var produtoResult = await _produtoService.CreateProduto(createProdutoInput);

        return produtoResult.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }
    
    [HttpPut("{idProduto:guid}/update")]
    public async Task<IActionResult> UpdateProduto([FromRoute]Guid idProduto, [FromBody]UpdateProdutoInput updateProdutoInput)
    {
        var produtoResult = await _produtoService.UpdateProduto(idProduto, updateProdutoInput);

        return produtoResult.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }
    
    [HttpDelete("{idProduto:guid}/delete")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idProduto)
    {
        var produtoResult = await _produtoService.DeleteProduto(idProduto);

        return produtoResult.Match(
            _ => NoContent(),
            errors => Problem(errors));
    }
}