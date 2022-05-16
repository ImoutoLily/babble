using Babble.Core.Models;
using FluentValidation;

namespace Babble.Core.Business.Validators;

public class UserAuthenticateValidator : AbstractValidator<UserAuthenticate>
{
    public UserAuthenticateValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithErrorCode("4326")
            .WithMessage("Invalid email adrress");

        RuleFor(x => x.UserName)
            .Matches("^(?=.*[a-zA-Z])[ a-zA-Z\\d\\-_]{4,32}$")
            .WithErrorCode("4598")
            .WithMessage("Invalid username");

        RuleFor(x => x.Password)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,32}$")
            .WithErrorCode("9345")
            .WithMessage("Invalid password");
    }
}