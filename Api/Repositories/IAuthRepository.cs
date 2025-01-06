using Models;

namespace Api.Repositories
{
    public interface IAuthRepository
    {
        Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail);
        Task<bool> AddUserAsync(User user);
    }
}
