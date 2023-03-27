namespace Orcamento.Application.Authentication.Dtos;

public class AuthenticationResponseDto
{
    public string Email { get; set; }
    public string Token { get; set; }

    public AuthenticationResponseDto()
    {
        
    }

    public AuthenticationResponseDto(string email, string token)
    {
        Email = email;
        Token = token;
    }
}