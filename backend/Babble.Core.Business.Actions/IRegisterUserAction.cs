using Babble.Core.Models;

namespace Babble.Core.Business.Actions;

public interface IRegisterUserAction
{
    Task<User> Register(UserAuthenticate userAuthenticate);
}