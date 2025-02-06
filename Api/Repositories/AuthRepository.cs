using Api.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface IAuthRepository
    {
        Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail);
        Task<bool> AddUserAsync(User user);
    }

    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameOrEmailAsync(string usernameOrEmail)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
        }

        public async Task<bool> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
