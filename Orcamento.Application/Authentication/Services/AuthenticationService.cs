using System.Security.Cryptography;
using System.Text;
using ErrorOr;
using Microsoft.EntityFrameworkCore;
using Orcamento.Application.Authentication.Dtos;
using Orcamento.Domain.Common.Errors;
using Orcamento.Domain.Entities;
using Orcamento.Infra.AppDbContext;

namespace Orcamento.Application.Authentication.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly OrcamentoDbContext _context;
    
    private readonly IJwtTokenGeneratorService _tokenGeneratorService;

    public AuthenticationService(OrcamentoDbContext context, IJwtTokenGeneratorService tokenGeneratorService)
    {
        _context = context;
        _tokenGeneratorService = tokenGeneratorService;
    }

    public async Task<ErrorOr<ValueTask>> Register(RegisterRequestInput registerRequestInput)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == registerRequestInput.Email);

        if (user is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        using var hmac = new HMACSHA512();

        var newUser = new User(
            Guid.NewGuid(), 
            registerRequestInput.FirstName,
            registerRequestInput.LastName,
            registerRequestInput.Email,
            hmac.ComputeHash(Encoding.UTF8.GetBytes(registerRequestInput.Password)),
            hmac.Key);

        await _context.Users.AddAsync(newUser);
        await _context.SaveChangesAsync();
        
        return ValueTask.CompletedTask;
    }
    
    public async Task<ErrorOr<AuthenticationResponseOutput>> Login(LoginRequestInput loginRequestInput)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == loginRequestInput.Email);

        if (user is null)
        {
            return Errors.Authentication.WrongEmailOrPassword;
        }

        using var hmac = new HMACSHA512(user.PasswordSalt);
        
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginRequestInput.Password));

        for (var i = 0; i < computedHash.Length; i++)
        {
            if (user.PasswordHash[i] != computedHash[i])
            {
                return Errors.Authentication.WrongEmailOrPassword;
            }
        }

        var token = _tokenGeneratorService.GenerateToken(user);

        var authResponse = new AuthenticationResponseOutput(
            user.Email,
            token);
        
        return authResponse;
    }
}