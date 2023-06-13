using Microsoft.AspNetCore.Mvc;
using Orcamento.Application.Authentication.Dtos;
using Orcamento.Application.Authentication.Services;
using Orcamento.Application.ErrorHandling;

namespace Orcamento.Application.Authentication.Controllers;

[Route("api/v1/authentication")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]RegisterRequestInput registerRequestInput)
    {
        var response = await _authenticationService.Register(registerRequestInput);

        return await response.MatchAsync<>(
            result => Ok(),
            errors => Problem(errors));
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequestInput loginRequestInput)
    {
        var user = await _authenticationService.Login(loginRequestInput);

        return await user.MatchAsync<>(
            result => Ok(user),
            errors => Problem(errors));
    }
    
}