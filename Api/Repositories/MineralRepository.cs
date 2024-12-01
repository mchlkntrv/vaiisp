using Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class MineralRepository(ApplicationDbContext context) : IMineralRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Mineral>> GetAllAsync() => await _context.Minerals.ToListAsync();

        public async Task<Mineral> GetByIdAsync(int id) => await _context.Minerals.FindAsync(id);

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
    }
}
