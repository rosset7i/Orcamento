using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Authentication.Dtos;
using Orcamento.Application.Authentication.Services;

namespace Orcamento.Application.Authentication.Controllers;

[ApiController, Authorize]
[Route("api/authentication")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterRequestDto registerRequestDto)
    {
        var user = await _authenticationService.Register(registerRequestDto);

        if (user is null)
        {
            return BadRequest("This email is already being used!");
        }

        return Ok("You've registered successfully!");
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequestDto loginRequestDto)
    {
        var user = await _authenticationService.Login(loginRequestDto);

        if (user is null)
        {
            return BadRequest("Wrong email or password!");
        }

        return Ok(user);
    }
    
}