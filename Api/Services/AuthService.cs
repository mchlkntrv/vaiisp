using Api.Repositories;
using Models;

namespace Api.Services
{
    public class AuthService(IAuthRepository authRepository) : IAuthService
    {
        private readonly IAuthRepository _authRepository = authRepository;

        public async Task<User> AuthenticateUserAsync(string usernameOrEmail, string password)
        {
            var user = await _authRepository.GetUserByUsernameOrEmailAsync(usernameOrEmail);

            if (user == null || user.PasswordHash != password)
            {
                return null;
            }

            return user;
        }
    }
}
