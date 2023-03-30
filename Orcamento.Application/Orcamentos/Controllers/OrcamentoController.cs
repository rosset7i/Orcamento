using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Orcamentos.Dtos;
using Orcamento.Application.Orcamentos.Enums;
using Orcamento.Application.Orcamentos.Services;

namespace Orcamento.Application.Orcamentos.Controllers;

[ApiController]
[Route("api/orcamentos")]
public class OrcamentoController : Controller
{
    private readonly OrcamentoService _orcamentoService;

    public OrcamentoController(OrcamentoService OrcamentoService)
    {
        _orcamentoService = OrcamentoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrcamentos()
    {
        var orcamento = await _orcamentoService.GetAllOrcamento();

        return Ok(orcamento);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrcamento([FromRoute]Guid idOrcamento)
    {
        var orcamento = await _orcamentoService.GetOrcamento(idOrcamento);

        return orcamento is not null ? Ok(orcamento) : NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOrcamento([FromBody]CreateOrcamentoInput createOrcamentoInput)
    {
        var orcamento = await _orcamentoService.CreateOrcamento(createOrcamentoInput);

        return orcamento == OperationResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrcamento([FromRoute]Guid idOrcamento, [FromBody]UpdateOrcamentoInput updateOrcamentoInput)
    {
        var orcamento = await _orcamentoService.UpdateOrcamento(idOrcamento, updateOrcamentoInput);

        return orcamento == OperationResult.Ok ? Ok() : BadRequest();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFornecedor([FromRoute]Guid idOrcamento)
    {
        var orcamento = await _orcamentoService.DeleteOrcamento(idOrcamento);

        return orcamento == OperationResult.Ok ? Ok() : BadRequest();
    }
}