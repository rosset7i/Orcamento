using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.ErrorHandling;
using Orcamento.Application.GenericServices.Models;
using Orcamento.Application.Orcamentos.Dtos;
using Orcamento.Application.Orcamentos.Services;

namespace Orcamento.Application.Orcamentos.Controllers;

[Route("api/v1/orcamentos")]
public class OrcamentoController : ApiController
{
    private readonly IOrcamentoService _orcamentoService;

    public OrcamentoController(IOrcamentoService orcamentoService)
    {
        _orcamentoService = orcamentoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrcamentos([FromQuery]PagedAndSortedRequest input)
    {
        return Ok(await _orcamentoService.GetAllOrcamento(input));
    }
    
    [HttpGet("{idOrcamento:guid}")]
    public async Task<IActionResult> GetOrcamento([FromRoute]Guid idOrcamento)
    {
        var orcamentoOutput = await _orcamentoService.GetOrcamento(idOrcamento);

        return orcamentoOutput.Match(
            result => Ok(result),
            error => Problem(error));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrcamento([FromBody]CreateOrcamentoInput createOrcamentoInput)
    {
        var orcamentoResult = await _orcamentoService.CreateOrcamento(createOrcamentoInput);

        return orcamentoResult.Match(
            result => NoContent(),
            errors => Problem(errors));
    }
    
    [HttpPut("{idOrcamento:guid}/update")]
    public async Task<IActionResult> UpdateOrcamento([FromRoute]Guid idOrcamento, [FromBody]UpdateOrcamentoInput updateOrcamentoInput)
    {
        var orcamentoResult = await _orcamentoService.UpdateOrcamento(idOrcamento, updateOrcamentoInput);

        return orcamentoResult.Match(
            result => NoContent(),
            errors => Problem(errors));
    }
    
    [HttpDelete("{idOrcamento:guid}/delete")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idOrcamento)
    {
        var orcamentoResult = await _orcamentoService.DeleteOrcamento(idOrcamento);

        return orcamentoResult.Match(
            result => NoContent(),
            errors => Problem(errors));
    }
}