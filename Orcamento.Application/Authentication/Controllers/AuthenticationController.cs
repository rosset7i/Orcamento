using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Authentication.Dtos;
using Orcamento.Application.Authentication.Enums;
using Orcamento.Application.Authentication.Services;
using Orcamento.Application.GenericServices;

namespace Orcamento.Application.Authentication.Controllers;

[ApiController]
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
        var response = await _authenticationService.Register(registerRequestDto);

        if (response == AuthenticationResult.EmailAlreadyUsed)
        {
            return BadRequest(AuthenticationResult.EmailAlreadyUsed);
        }

        return Ok(response);
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