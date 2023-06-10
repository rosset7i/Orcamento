using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Authentication.Dtos;
using Orcamento.Application.Authentication.Enums;
using Orcamento.Application.Authentication.Services;

namespace Orcamento.Application.Authentication.Controllers;

[ApiController]
[Route("api/v1/authentication")]
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
        var response = await _authenticationService.Register(registerRequestDto);

        return response == AuthenticationResult.EmailAlreadyUsed
            ? Problem(
                statusCode: StatusCodes.Status409Conflict,
                detail: "Email Already In Use!")
            : Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequestDto loginRequestDto)
    {
        var user = await _authenticationService.Login(loginRequestDto);

        if (user is null)
        {
            return BadRequest(AuthenticationResult.WrongEmailOrPassword);
        }

        return Ok(user);
    }
    
}