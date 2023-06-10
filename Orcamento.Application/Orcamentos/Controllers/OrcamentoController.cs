using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Orcamentos.Dtos;
using Orcamento.Application.Orcamentos.Enums;
using Orcamento.Application.Orcamentos.Services;

namespace Orcamento.Application.Orcamentos.Controllers;

[ApiController]
[Route("api/v1/orcamentos")]
public class OrcamentoController : ControllerBase
{
    private readonly OrcamentoService _orcamentoService;

    public OrcamentoController(OrcamentoService OrcamentoService)
    {
        _orcamentoService = OrcamentoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrcamentos()
    {
        return Ok(await _orcamentoService.GetAllOrcamento());
    }
    
    [HttpGet("{idOrcamento:guid}")]
    public async Task<IActionResult> GetOrcamento([FromRoute]Guid idOrcamento)
    {
        return Ok(await _orcamentoService.GetOrcamento(idOrcamento));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrcamento([FromBody]CreateOrcamentoInput createOrcamentoInput)
    {
        var orcamento = await _orcamentoService.CreateOrcamento(createOrcamentoInput);

        return orcamento is OrcamentoResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpPut("{idOrcamento:guid}")]
    public async Task<IActionResult> UpdateOrcamento([FromRoute]Guid idOrcamento, [FromBody]UpdateOrcamentoInput updateOrcamentoInput)
    {
        var orcamento = await _orcamentoService.UpdateOrcamento(idOrcamento, updateOrcamentoInput);

        return orcamento == OrcamentoResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpDelete("{idOrcamento:guid}")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idOrcamento)
    {
        var orcamento = await _orcamentoService.DeleteOrcamento(idOrcamento);

        return orcamento == OrcamentoResult.Ok ? Ok() : BadRequest();
    }
}