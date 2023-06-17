using FluentAssertions;
using NSubstitute;
using Orcamento.Application.Authentication.Dtos;
using Orcamento.Domain.Common.Errors;
using Orcamento.Domain.Entities;
using Orcamento.UnitTest.UnitTests.Authentication.TestUtils;
using Xunit;

namespace Orcamento.UnitTest.UnitTests.Authentication.Services;

public class AuthenticationServiceTests
{
    [Fact]
    public async Task Register_WhenEmailDoesntExist_ShouldSaveNewUser()
    {
        //Arrange
        var registerRequestInput = CreateAuthenticationUtils.CreateRegisterRequestInput();
        var mocks = CreateAuthenticationUtils.GetMocks();
        var service = CreateAuthenticationUtils.GetService(mocks);
        
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
        var mocks = CreateAuthenticationUtils.GetMocks();
        var service = CreateAuthenticationUtils.GetService(mocks);  

        await mocks.OrcamentoDbContext.Users.AddAsync(user);
        await mocks.OrcamentoDbContext.SaveChangesAsync();
        
        //Act
        var result = await service.Register(registerRequestInput);

        //Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().Be(Errors.User.DuplicateEmail);
    }
    
    //TODO pesquisar como testar hashing
    
    [Fact]
    public async Task Login_WhenUserWithEmailDoesntExists_ShouldReturnError()
    {
        //Arrange
        var user = CreateAuthenticationUtils.CreateUser();
        var loginRequestInput = CreateAuthenticationUtils.CreateLoginRequestInput();
        
        var mocks = CreateAuthenticationUtils.GetMocks();
        var service = CreateAuthenticationUtils.GetService(mocks);

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
        
        var mocks = CreateAuthenticationUtils.GetMocks();
        var service = CreateAuthenticationUtils.GetService(mocks);

        await mocks.OrcamentoDbContext.Users.AddAsync(user);
        await mocks.OrcamentoDbContext.SaveChangesAsync();
        
        //Act
        var result = await service.Login(loginRequestInput);

        //Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().Be(Errors.Authentication.WrongEmailOrPassword);
    }
}