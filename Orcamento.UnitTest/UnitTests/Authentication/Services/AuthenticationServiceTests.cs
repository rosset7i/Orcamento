using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Orcamento.Application.Authentication.Services;
using Orcamento.Domain.Common.Errors;
using Orcamento.Domain.Entities;
using Orcamento.Infra.AppDbContext;
using Orcamento.UnitTest.TestUtils;
using Orcamento.UnitTest.UnitTests.Authentication.TestUtils;
using Xunit;

namespace Orcamento.UnitTest.UnitTests.Authentication.Services;

public class AuthenticationServiceTests : IUnitTestBase<AuthenticationService, AuthenticationServiceMock>
{
    [Fact]
    public async Task Register_WhenEmailDoesntExist_ShouldSaveNewUser()
    {
        //Arrange
        var registerRequestInput = CreateAuthenticationUtils.CreateRegisterRequestInput();
        var mocks = GetMocks();
        var service = GetClass(mocks);
        
        //Act
        var result = await service.Register(registerRequestInput);

        //Assert
        result.IsError.Should().BeFalse();
    }
    
    [Fact]
    public async Task Register_WhenUserWithEmailExists_ShouldReturnConflictError()
    {
        //Arrange
        var user = CreateAuthenticationUtils.CreateUser();
        var registerRequestInput = CreateAuthenticationUtils.CreateRegisterRequestInput();
        
        var mocks = GetMocks();
        var service = GetClass(mocks);  

        await mocks.OrcamentoDbContext.Users.AddAsync(user);
        await mocks.OrcamentoDbContext.SaveChangesAsync();
        
        //Act
        var result = await service.Register(registerRequestInput);

        //Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().Be(Errors.User.DuplicateEmail);
        mocks.JwtTokenGeneratorService
            .ReceivedWithAnyArgs(0)
            .GenerateToken(new User());
    }
    
    //TODO pesquisar como testar hashing
    
    [Fact]
    public async Task Login_WhenUserWithEmailDoesntExists_ShouldReturnError()
    {
        //Arrange
        var loginRequestInput = CreateAuthenticationUtils.CreateLoginRequestInput();
        
        var mocks = GetMocks();
        var service = GetClass(mocks);

        //Act
        var result = await service.Login(loginRequestInput);

        //Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().Be(Errors.Authentication.WrongEmailOrPassword);
    }
    
    [Fact]
    public async Task Login_WhenPasswordDoesntCheck_ShouldReturnError()
    {
        //Arrange
        var user = CreateAuthenticationUtils.CreateUser();
        var loginRequestInput = CreateAuthenticationUtils.CreateLoginRequestInput();
        
        var mocks = GetMocks();
        var service = GetClass(mocks);

        await mocks.OrcamentoDbContext.Users.AddAsync(user);
        await mocks.OrcamentoDbContext.SaveChangesAsync();
        
        //Act
        var result = await service.Login(loginRequestInput);

        //Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().Be(Errors.Authentication.WrongEmailOrPassword);
    }

    public AuthenticationServiceMock GetMocks()
    {
        var options = new DbContextOptionsBuilder<OrcamentoDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        return new AuthenticationServiceMock
        {
            OrcamentoDbContext = new OrcamentoDbContext(options),
            JwtTokenGeneratorService = Substitute.For<IJwtTokenGeneratorService>()
        };
    }

    public AuthenticationService GetClass(AuthenticationServiceMock mocks)
    {
        return new AuthenticationService(
            mocks.OrcamentoDbContext,
            mocks.JwtTokenGeneratorService);
    }
}

public class AuthenticationServiceMock
{
    public OrcamentoDbContext OrcamentoDbContext { get; init; }
    public IJwtTokenGeneratorService JwtTokenGeneratorService { get; init; }
}