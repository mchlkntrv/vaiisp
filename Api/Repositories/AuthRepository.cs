using Api.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Repositories
{
    public class AuthRepository(ApplicationDbContext context) : IAuthRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
        }
    }
}
