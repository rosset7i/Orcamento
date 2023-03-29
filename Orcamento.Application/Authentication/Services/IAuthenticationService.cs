using Orcamento.Application.Authentication.Dtos;

namespace Orcamento.Application.Authentication.Services;

public interface IAuthenticationService
{
    Task<AuthenticationResponseDto> Register(RegisterRequestDto registerRequestDto);
    Task<AuthenticationResponseDto> Login(LoginRequestDto loginRequestDto);
}