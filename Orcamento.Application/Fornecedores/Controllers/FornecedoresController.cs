using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Application.Fornecedores.Enums;
using Orcamento.Application.Fornecedores.Services;

namespace Orcamento.Application.Fornecedores.Controllers;

[ApiController]
[Route("api/fornecedores")]
public class FornecedoresController : Controller
{
    private readonly FornecedorService _fornecedorService;

    public FornecedoresController(FornecedorService fornecedorService)
    {
        _fornecedorService = fornecedorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFornecedores()
    {
        var fornecedores = await _fornecedorService.GetAllFornecedores();

        return Ok(fornecedores);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFornecedor([FromRoute]Guid idFornecedor)
    {
        var fornecedor = await _fornecedorService.GetFornecedor(idFornecedor);

        return fornecedor is not null ? Ok(fornecedor) : NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFornecedor([FromBody]CreateFornecedorInput createFornecedorInput)
    {
        var fornecedor = await _fornecedorService.CreateFornecedor(createFornecedorInput);

        return fornecedor == FornecedorResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFornecedor([FromRoute]Guid idFornecedor, [FromBody]UpdateFornecedorInput updateFornecedorInput)
    {
        var fornecedor = await _fornecedorService.UpdateFornecedor(idFornecedor, updateFornecedorInput);

        return fornecedor == FornecedorResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idFornecedor)
    {
        var fornecedor = await _fornecedorService.DeleteFornecedor(idFornecedor);

        return fornecedor == FornecedorResult.Ok ? Ok() : BadRequest();
    }
}