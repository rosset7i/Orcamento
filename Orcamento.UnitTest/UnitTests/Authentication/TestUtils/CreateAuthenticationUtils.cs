using Orcamento.Application.Authentication.Dtos;
using Orcamento.UnitTest.TestUtils;

namespace Orcamento.UnitTest.UnitTests.Authentication.TestUtils;

public static class CreateAuthenticationUtils
{
    public static RegisterRequestInput CreateUser()
    {
        return new RegisterRequestInput(
            Constants.User.FirstName,
            Constants.User.LastName,
            Constants.User.Email,
            Constants.User.Password);
    }
}