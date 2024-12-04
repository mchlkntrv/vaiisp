using Models;

namespace Api.Services
{
    public interface IMineralService
    {
        Task<List<Mineral>> GetAllMineralsAsync();
        Task<Mineral?> GetMineralByIdAsync(int id);
        Task<bool> AddMineralAsync(Mineral mineral);
        Task<bool> UpdateMineralAsync(int id, Mineral mineral);
        Task DeleteMineralAsync(int id);
    }
}
