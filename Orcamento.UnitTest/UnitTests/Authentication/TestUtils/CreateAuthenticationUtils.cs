using Orcamento.Application.Authentication.Dtos;
using Orcamento.Domain.Entities;
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
    
    public static AuthenticationResponseOutput CreateLoginResponseOutput() => 
        new(Constants.User.Email,
            Constants.User.Token);
    
    public static User CreateUser() => 
        new (Guid.NewGuid(),
            Constants.User.FirstName,
            Constants.User.LastName,
            Constants.User.Email,
            new byte[64],
            new byte[64]);
}

