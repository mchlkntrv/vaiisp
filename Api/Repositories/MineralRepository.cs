using Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public interface IMineralRepository
    {
        Task<List<Mineral>> GetAllAsync();
        Task<Mineral> GetByIdAsync(int id);
        Task<Mineral?> GetByNameAsync(string name);
        Task AddAsync(Mineral mineral);
        Task UpdateAsync(Mineral mineral);
        Task DeleteAsync(int id);
        Task<List<Mineral>> SearchMineralsAsync(string query);
    }

    public class MineralRepository : IMineralRepository
    {
        private readonly ApplicationDbContext _context;

        public MineralRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mineral>> GetAllAsync() => await _context.Minerals.ToListAsync();

        public async Task<Mineral> GetByIdAsync(int id) => await _context.Minerals.FindAsync(id);

        public async Task<Mineral?> GetByNameAsync(string name)
        {
            return await _context.Minerals
                .FirstOrDefaultAsync(m => m.Name.ToLower() == name.ToLower());
        }

        public async Task AddAsync(Mineral mineral)
        {
            _context.Minerals.Add(mineral);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mineral mineral)
        {
            _context.Minerals.Update(mineral);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mineral = await _context.Minerals.FindAsync(id);
            if (mineral != null)
            {
                _context.Minerals.Remove(mineral);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Mineral>> SearchMineralsAsync(string query)
        {
            return await _context.Minerals
                .Where(m => m.Name.Contains(query))
                .ToListAsync();
        }
    }
}
