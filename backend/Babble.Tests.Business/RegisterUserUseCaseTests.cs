using System.Linq;
using System.Threading.Tasks;
using Babble.Core.Business.Actions;
using Babble.Core.Business.UseCases;
using Babble.Core.Business.Validators;
using Babble.Core.Models;
using Moq;
using Xunit;

namespace Babble.Tests.Business;

public class RegisterUserUseCaseTests
{
    private readonly RegisterUserUseCase _registerUser;
    private readonly Mock<IRegisterUserActions> _registerUserActionsMock = new();

    public RegisterUserUseCaseTests()
    {
        _registerUser = new RegisterUserUseCase(new UserAuthenticateValidator(), 
            _registerUserActionsMock.Object);
    }

    [Theory]
    [InlineData("bob@hotmail.com", "Bobby", "Super7secure@")]
    [InlineData("someone@gmail.be", "Linda_", "Str0ngP@$$word")]
    [InlineData("me@mail.co.uk", "Bob Marley", "Password123*")]
    [InlineData("someone@hotmail.com", "some-cool-person", "Traaa5_*UwU")]
    public async Task Register_ShouldBeSuccessful(string email, string userName, string password)
    {
        var authenticate = new UserAuthenticate
        {
            Email = email,
            UserName = userName,
            Password = password
        };
        
        _registerUserActionsMock.Setup(x => x.IsEmailInUse(authenticate.Email))
            .ReturnsAsync(false);
        _registerUserActionsMock.Setup(x => x.IsUserNameInUse(authenticate.UserName))
            .ReturnsAsync(false);
        _registerUserActionsMock.Setup(x => x.Register(authenticate))
            .ReturnsAsync(new User { Email = authenticate.Email, UserName = authenticate.UserName });

        var result = await _registerUser.Register(authenticate);
        
        Assert.True(result.Success);
        Assert.Equal(result.Data?.Email, email);
        Assert.Equal(result.Data?.UserName, userName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("just some text")]
    [InlineData("not@a@email.com")]
    [InlineData("@hotmail.com")]
    public async Task Register_ShouldHaveInvalidEmail(string email)
    {
        var authenticate = new UserAuthenticate
        {
            Email = email,
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

    [Theory]
    [InlineData("")]
    [InlineData("MyUsername@")]
    [InlineData("My far too long username that will never ever be valid")]
    [InlineData("123456789")]
    public async Task Register_ShouldHaveInvalidUserName(string userName)
    {
        var authenticate = new UserAuthenticate
        {
            Email = "myemail@hotmail.com",
            UserName = userName,
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
        Assert.Equal("1001", result.Errors.First().Code);
    }

    [Theory]
    [InlineData("")]
    [InlineData("Invalidpassword")]
    [InlineData("@@@@@@@@@@123")]
    [InlineData("waaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaytoolong")]
    public async Task Register_ShouldHaveInvalidPassword(string password)
    {
        var authenticate = new UserAuthenticate
        {
            Email = "myemail@hotmail.com",
            UserName = "Someone",
            Password = password
        };

        _registerUserActionsMock.Setup(x => x.IsEmailInUse(authenticate.Email))
            .ReturnsAsync(false);
        _registerUserActionsMock.Setup(x => x.IsUserNameInUse(authenticate.UserName))
            .ReturnsAsync(false);
        _registerUserActionsMock.Setup(x => x.Register(authenticate))
            .ReturnsAsync(new User { Email = authenticate.Email, UserName = authenticate.UserName });

        var result = await _registerUser.Register(authenticate);
        
        Assert.Equal(1, result.Errors.Count);
        Assert.Equal("1002", result.Errors.First().Code);
    }

    [Fact]
    public async Task Register_ShouldHaveEmailAlreadyInUse()
    {
        var authenticate = new UserAuthenticate
        {
            Email = "myemail@hotmail.com",
            UserName = "Someone",
            Password = "Password123*"
        };

        _registerUserActionsMock.Setup(x => x.IsEmailInUse(authenticate.Email))
            .ReturnsAsync(true);
        _registerUserActionsMock.Setup(x => x.IsUserNameInUse(authenticate.UserName))
            .ReturnsAsync(false);
        _registerUserActionsMock.Setup(x => x.Register(authenticate))
            .ReturnsAsync(new User());

        var result = await _registerUser.Register(authenticate);
        
        Assert.Equal(1, result.Errors.Count);
        Assert.Equal("1003", result.Errors.First().Code);
    }

    [Fact]
    public async Task Register_ShouldHaveUserNameAlreadyInUse()
    {
        var authenticate = new UserAuthenticate
        {
            Email = "myemail@hotmail.com",
            UserName = "Someone",
            Password = "Password123*"
        };

        _registerUserActionsMock.Setup(x => x.IsEmailInUse(authenticate.Email))
            .ReturnsAsync(false);
        _registerUserActionsMock.Setup(x => x.IsUserNameInUse(authenticate.UserName))
            .ReturnsAsync(true);
        _registerUserActionsMock.Setup(x => x.Register(authenticate))
            .ReturnsAsync(new User());

        var result = await _registerUser.Register(authenticate);
        
        Assert.Equal(1, result.Errors.Count);
        Assert.Equal("1004", result.Errors.First().Code);
    }
}