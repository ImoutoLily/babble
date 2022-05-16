using Babble.Core.Business.Actions;
using Babble.Core.Business.Validators;
using Babble.Core.Models;

namespace Babble.Core.Business.UseCases;

public class RegisterUserUseCase
{
    private readonly UserAuthenticateValidator _validator;
    private readonly IRegisterUserAction _registerUser;

    public RegisterUserUseCase(UserAuthenticateValidator validator, IRegisterUserAction registerUser)
    {
        _validator = validator;
        _registerUser = registerUser;
    }

    public async Task<Result<User>> Register(UserAuthenticate userAuthenticate)
    {
        var result = _validator.Validate(userAuthenticate);

        if (!result.IsValid)
        {
            return Result.FailFromValidation<User>(result.Errors);
        }

        if (await _registerUser.IsEmailInUse(userAuthenticate.Email!))
        {
            
        }

        if (await _registerUser.IsUserNameInUse(userAuthenticate.UserName!))
        {
            
        }

        var user = await _registerUser.Register(userAuthenticate);

        return Result.Ok(user);
    }
}