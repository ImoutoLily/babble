using Babble.Core.Business.Actions;
using Babble.Core.Models;
using Babble.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Babble.Adapters.Gateways;

// TODO: update when authentication is implemented
public class RegisterUserActions : IRegisterUserActions
{
    private readonly BabbleContext _context;

    public RegisterUserActions(BabbleContext context)
    {
        _context = context;
    }

    public async Task<bool> IsEmailInUse(string email)
    {
        return await _context.Users
            .Where(x => string.Equals(x.Email, email, StringComparison.CurrentCultureIgnoreCase))
            .AnyAsync();
    }

    public async Task<bool> IsUserNameInUse(string userName)
    {
        return await _context.Users
            .Where(x => string.Equals(x.UserName, userName, StringComparison.CurrentCultureIgnoreCase))
            .AnyAsync();
    }

    public async Task<User> Register(UserAuthenticate userAuthenticate)
    {
        var user = new User
        {
            Email = userAuthenticate.Email!,
            UserName = userAuthenticate.UserName!
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }
}