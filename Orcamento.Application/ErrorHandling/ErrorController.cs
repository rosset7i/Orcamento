using Microsoft.AspNetCore.Mvc;

namespace Orcamento.Application.ErrorHandling;

[ApiController]
[Route("/error")]
public class ErrorController : ControllerBase
{
    public IActionResult Error()
    {
        return Problem();
    }
}