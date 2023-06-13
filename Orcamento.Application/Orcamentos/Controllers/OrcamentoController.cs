using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.ErrorHandling;
using Orcamento.Application.Orcamentos.Dtos;
using Orcamento.Application.Orcamentos.Services;

namespace Orcamento.Application.Orcamentos.Controllers;

[Route("api/v1/orcamentos")]
public class OrcamentoController : ApiController
{
    private readonly OrcamentoService _orcamentoService;

    public OrcamentoController(OrcamentoService orcamentoService)
    {
        _orcamentoService = orcamentoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrcamentos()
    {
        return Ok(await _orcamentoService.GetAllOrcamento());
    }
    
    [HttpGet("{idOrcamento:guid}")]
    public async Task<IActionResult> GetOrcamento([FromRoute]Guid idOrcamento)
    {
        var orcamentoOutput = await _orcamentoService.GetOrcamento(idOrcamento);

        return await orcamentoOutput.MatchAsync<>(
            result => Ok(result),
            error => Problem(error));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrcamento([FromBody]CreateOrcamentoInput createOrcamentoInput)
    {
        var orcamentoResult = await _orcamentoService.CreateOrcamento(createOrcamentoInput);

        return await orcamentoResult.MatchAsync<>(
            result => NoContent(),
            errors => Problem(errors));
    }
    
    [HttpPut("{idOrcamento:guid}")]
    public async Task<IActionResult> UpdateOrcamento([FromRoute]Guid idOrcamento, [FromBody]UpdateOrcamentoInput updateOrcamentoInput)
    {
        var orcamentoResult = await _orcamentoService.UpdateOrcamento(idOrcamento, updateOrcamentoInput);

        return await orcamentoResult.MatchAsync<>(
            result => NoContent(),
            errors => Problem(errors));
    }
    
    [HttpDelete("{idOrcamento:guid}")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idOrcamento)
    {
        var orcamentoResult = await _orcamentoService.DeleteOrcamento(idOrcamento);

        return await orcamentoResult.MatchAsync<>(
            result => NoContent(),
            errors => Problem(errors));
    }
}