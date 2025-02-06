using Models;

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
}
