using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.ErrorHandling;
using Orcamento.Application.Fornecedores.Dtos;
using Orcamento.Application.Fornecedores.Services;
using Orcamento.Application.GenericServices.Models;

namespace Orcamento.Application.Fornecedores.Controllers;

[Route("api/v1/fornecedores")]
public class FornecedoresController : ApiController
{
    private readonly IFornecedorService _fornecedorService;

    public FornecedoresController(IFornecedorService fornecedorService)
    {
        _fornecedorService = fornecedorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFornecedores([FromQuery]PagedAndSortedRequest input)
    {
        return Ok(await _fornecedorService.GetAllFornecedores(input));
    }
    
    [HttpGet("{idFornecedor:guid}")]
    public async Task<IActionResult> GetFornecedor([FromRoute]Guid idFornecedor)
    {
        var result = await _fornecedorService.GetFornecedor(idFornecedor);

        return result.Match(
            fornecedorOutput => Ok(fornecedorOutput),
            errors => Problem(errors));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFornecedor([FromBody]CreateFornecedorInput createFornecedorInput)
    {
        var result = await _fornecedorService.CreateFornecedor(createFornecedorInput);

        return result.Match(
            resultOutput => NoContent(),
            error => Problem(error));
    }
    
    [HttpPut("{idFornecedor:guid}/update")]
    public async Task<IActionResult> UpdateFornecedor([FromRoute]Guid idFornecedor, [FromBody]UpdateFornecedorInput updateFornecedorInput)
    {
        var result = await _fornecedorService.UpdateFornecedor(idFornecedor, updateFornecedorInput);

        return result.Match(
            resultOutput => NoContent(),
            error => Problem(error));
    }
    
    [HttpDelete("{idFornecedor:guid}/delete")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idFornecedor)
    {
        var result = await _fornecedorService.DeleteFornecedor(idFornecedor);

        return result.Match(
            resultOutput => NoContent(),
            error => Problem(error));
    }
}