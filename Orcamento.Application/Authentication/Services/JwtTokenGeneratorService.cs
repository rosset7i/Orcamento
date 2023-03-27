using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Orcamento.Application.Authentication.Dtos;
using Orcamento.Application.GenericServices;

namespace Orcamento.Application.Authentication.Services;

public class JwtTokenGeneratorService : IJwtTokenGeneratorService
{
    private readonly IDateTimeProviderService _dateTimeProviderService;
    private readonly IConfiguration _configuration;

    public JwtTokenGeneratorService(IDateTimeProviderService dateTimeProviderService,
        IConfiguration configuration)
    {
        _dateTimeProviderService = dateTimeProviderService;
        _configuration = configuration;
    }
    public async Task<string> GenerateToken(Guid id, string email)
    {
        var key = _configuration.GetSection("JwtSettings:Secret").Value!;
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Secret").Value!)),
            SecurityAlgorithms.HmacSha512);
            
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.Role, "User")
        };

        var securityToken = new JwtSecurityToken(
            expires: _dateTimeProviderService.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}