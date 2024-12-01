using Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class MineralService(ApplicationDbContext context) : IMineralService
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Mineral>> GetAllMineralsAsync()
        {
            return await _context.Minerals.ToListAsync();
        }

        public async Task<Mineral> GetMineralByIdAsync(int id)
        {
            return await _context.Minerals
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task CreateMineralAsync(Mineral mineral)
        {
            _context.Minerals.Add(mineral);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMineralAsync(Mineral mineral)
        {
            _context.Minerals.Update(mineral);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMineralAsync(int id)
        {
            var mineral = await _context.Minerals
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mineral != null)
            {
                _context.Minerals.Remove(mineral);
                await _context.SaveChangesAsync();
            }
        }
    }
}
