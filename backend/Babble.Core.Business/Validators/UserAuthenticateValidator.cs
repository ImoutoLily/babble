using Babble.Core.Models;
using FluentValidation;

namespace Babble.Core.Business.Validators;

public class UserAuthenticateValidator : AbstractValidator<UserAuthenticate>
{
    public UserAuthenticateValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithErrorCode(Error.InvalidEmail.Code)
            .WithMessage(Error.InvalidEmail.Message);

        RuleFor(x => x.UserName)
            .Matches("^(?=.*[a-zA-Z])[ a-zA-Z\\d\\-_]{4,32}$")
            .WithErrorCode(Error.InvalidUserName.Code)
            .WithMessage(Error.InvalidUserName.Message);

        RuleFor(x => x.Password)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,32}$")
            .WithErrorCode(Error.InvalidPassword.Code)
            .WithMessage(Error.InvalidPassword.Message);
    }
}