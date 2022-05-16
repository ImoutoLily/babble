using Babble.Core.Models;

namespace Babble.Core.Business.Actions;

public interface IRegisterUserActions
{
    Task<bool> IsEmailInUse(string email);
    Task<bool> IsUserNameInUse(string userName);
    Task<User> Register(UserAuthenticate userAuthenticate);
}