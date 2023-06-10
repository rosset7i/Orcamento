using Orcamento.Domain.Entities;

namespace Orcamento.Application.Authentication.Services;

public interface IJwtTokenGeneratorService
{
    string GenerateToken(User user);
}