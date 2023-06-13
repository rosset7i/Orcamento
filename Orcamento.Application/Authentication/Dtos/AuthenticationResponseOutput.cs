namespace Orcamento.Application.Authentication.Dtos;

public class AuthenticationResponseOutput
{
    private string Email { get; }
    private string Token { get; }

    public AuthenticationResponseOutput()
    {
        
    }

    public AuthenticationResponseOutput(string email, string token)
    {
        Email = email;
        Token = token;
    }
}