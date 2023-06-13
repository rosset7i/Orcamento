using ErrorOr;
using Orcamento.Application.Authentication.Dtos;

namespace Orcamento.Application.Authentication.Services;

public interface IAuthenticationService
{
    Task<ErrorOr<ValueTask>> Register(RegisterRequestInput registerRequestInput);
    Task<ErrorOr<AuthenticationResponseOutput>> Login(LoginRequestInput loginRequestInput);
}