using System;
using System.Linq;
using System.Threading.Tasks;
using Babble.Core.Business.Actions;
using Babble.Core.Business.UseCases;
using Babble.Core.Business.Validators;
using Babble.Core.Models;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Babble.Tests.Business;

public class RegisterUserUseCaseTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly RegisterUserUseCase _registerUser;
    private readonly Mock<IRegisterUserActions> _registerUserActionsMock = new();

    public RegisterUserUseCaseTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _registerUser = new RegisterUserUseCase(new UserAuthenticateValidator(), 
            _registerUserActionsMock.Object);
    }

    [Fact]
    public async Task Register_ShouldHaveInvalidEmail()
    {
        var authenticate = new UserAuthenticate
        {
            Email = "",
            UserName = "Bobby",
            Password = "Password123*"
        };

        _registerUserActionsMock.Setup(x => x.IsEmailInUse(authenticate.Email))
            .ReturnsAsync(false);
        _registerUserActionsMock.Setup(x => x.IsUserNameInUse(authenticate.UserName))
            .ReturnsAsync(false);
        _registerUserActionsMock.Setup(x => x.Register(authenticate))
            .ReturnsAsync(new User { Email = authenticate.Email, UserName = authenticate.UserName });

        var result = await _registerUser.Register(authenticate);
        
        Assert.Equal(1, result.Errors.Count);
        Assert.Equal("1000", result.Errors.First().Code);
    }
}