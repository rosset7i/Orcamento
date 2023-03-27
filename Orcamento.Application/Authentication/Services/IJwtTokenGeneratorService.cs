namespace Orcamento.Application.Authentication.Services;

public interface IJwtTokenGeneratorService
{
    Task<string> GenerateToken(Guid id, string email);
}