using Models;

namespace Api.Services
{
    public interface IMineralService
    {
        Task<List<Mineral>> GetAllMineralsAsync();
        Task<Mineral> GetMineralByIdAsync(int id);
        Task CreateMineralAsync(Mineral mineral);
        Task UpdateMineralAsync(Mineral mineral);
        Task DeleteMineralAsync(int id);
    }
}
