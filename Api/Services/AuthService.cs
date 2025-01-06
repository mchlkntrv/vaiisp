using Api.Repositories;
using Models;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<User> AuthenticateUserAsync(string usernameOrEmail, string password)
        {
            var user = await _authRepository.GetUserByUsernameOrEmailAsync(usernameOrEmail);

            if (user == null)
            {
                return null;
            }

            string hashedPassword = HashPassword(password, user.Salt);
            if (user.Password != hashedPassword)
            {
                return null;
            }

            return user;
        }

        public async Task<bool> RegisterUserAsync(RegistrationModel registerModel)
        {
            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                return false;
            }

            string salt = GenerateSalt();
            string hashedPassword = HashPassword(registerModel.Password, salt);

            var user = new User
            {
                FullName = $"{registerModel.FirstName} {registerModel.LastName}",
                Username = registerModel.Username,
                Email = registerModel.Email,
                Password = hashedPassword,
                Salt = salt,
                Role = "user"
            };

            return await _authRepository.AddUserAsync(user);
        }

        private string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
