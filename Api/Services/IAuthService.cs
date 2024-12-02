using Models;

namespace Api.Services
{
    public interface IAuthService
    {
        Task<User> AuthenticateUserAsync(string usernameOrEmail, string password);
    }
}
