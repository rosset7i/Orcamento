using System.Text;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Orcamento.Application.Authentication.Dtos;
using Orcamento.Application.Authentication.Services;
using Orcamento.Domain.Entities;
using Orcamento.Infra.AppDbContext;
using Orcamento.UnitTest.TestUtils;

namespace Orcamento.UnitTest.UnitTests.Authentication.TestUtils;

public static class CreateAuthenticationUtils
{
    public static RegisterRequestInput CreateRegisterRequestInput() => 
        new(Constants.User.FirstName,
            Constants.User.LastName,
            Constants.User.Email,
            Constants.User.Password);
    
    public static LoginRequestInput CreateLoginRequestInput() => 
        new(Constants.User.Email,
            Constants.User.Password);
    
    public static User CreateUser() => 
        new (Guid.NewGuid(),
            Constants.User.FirstName,
            Constants.User.LastName,
            Constants.User.Email,
            new byte[64],
            new byte[64]);

    public static AuthenticationService GetService(AuthenticationMock authenticationMock)
    {
        return new AuthenticationService(
            authenticationMock.OrcamentoDbContext,
            authenticationMock.JwtTokenGeneratorService);
    }
    
    public static AuthenticationMock GetMocks()
    {
        var options = new DbContextOptionsBuilder<OrcamentoDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        return new AuthenticationMock
        {
            OrcamentoDbContext = new OrcamentoDbContext(options),
            JwtTokenGeneratorService = Substitute.For<IJwtTokenGeneratorService>()
        };
    }
    
}

public class AuthenticationMock
{
    public OrcamentoDbContext OrcamentoDbContext { get; init; }
    public IJwtTokenGeneratorService JwtTokenGeneratorService { get; init; }
}