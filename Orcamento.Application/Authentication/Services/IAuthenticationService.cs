using Orcamento.Application.Authentication.Dtos;
using Orcamento.Application.Authentication.Enums;

namespace Orcamento.Application.Authentication.Services;

public interface IAuthenticationService
{
    Task<AuthenticationResult> Register(RegisterRequestDto registerRequestDto);
    Task<AuthenticationResponseDto> Login(LoginRequestDto loginRequestDto);
}