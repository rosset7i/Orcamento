using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Application.Fornecedores.Enums;
using Orcamento.Application.Fornecedores.Services;

namespace Orcamento.Application.Fornecedores.Controllers;

[ApiController]
[Route("api/v1/fornecedores")]
public class FornecedoresController : ControllerBase
{
    private readonly FornecedorService _fornecedorService;

    public FornecedoresController(FornecedorService fornecedorService)
    {
        _fornecedorService = fornecedorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFornecedores()
    {
        return Ok(await _fornecedorService.GetAllFornecedores());
    }
    
    [HttpGet("{idFornecedor:guid}")]
    public async Task<IActionResult> GetFornecedor([FromRoute]Guid idFornecedor)
    {
        return Ok(await _fornecedorService.GetFornecedor(idFornecedor));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFornecedor([FromBody]CreateFornecedorInput createFornecedorInput)
    {
        var fornecedorResult = await _fornecedorService.CreateFornecedor(createFornecedorInput);

        return fornecedorResult is FornecedorResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpPut("{idFornecedor:guid}/update")]
    public async Task<IActionResult> UpdateFornecedor([FromRoute]Guid idFornecedor, [FromBody]UpdateFornecedorInput updateFornecedorInput)
    {
        var fornecedor = await _fornecedorService.UpdateFornecedor(idFornecedor, updateFornecedorInput);

        return fornecedor == FornecedorResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpDelete("{idFornecedor:guid}/delete")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idFornecedor)
    {
        var fornecedor = await _fornecedorService.DeleteFornecedor(idFornecedor);

        return fornecedor == FornecedorResult.Ok ? Ok() : BadRequest();
    }
}