using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Orcamento.Application.GenericServices;
using Orcamento.Domain.Entities;

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
    public string GenerateToken(User user)
    {
        var key = _configuration.GetSection("JwtSettings:Secret").Value!;
        
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            SecurityAlgorithms.HmacSha512);
            
        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, "Admin"),
            new(ClaimTypes.Role, "User")
        };

        var securityToken = new JwtSecurityToken(
            expires: _dateTimeProviderService.UtcNow.AddMinutes(60),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}