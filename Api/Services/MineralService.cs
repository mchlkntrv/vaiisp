using Models;
using Api.Repositories;

namespace Api.Services
{
    public class MineralService : IMineralService
    {
        private readonly IMineralRepository _mineralRepository;

        public MineralService(IMineralRepository mineralRepository)
        {
            _mineralRepository = mineralRepository;
        }

        public async Task<List<Mineral>> GetAllMineralsAsync()
        {
            return await _mineralRepository.GetAllAsync();
        }

        public async Task<Mineral?> GetMineralByIdAsync(int id)
        {
            return await _mineralRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddMineralAsync(Mineral mineral)
        {
            if (mineral == null)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(mineral.Name))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(mineral.Information))
            {
                return false;
            }

            var existingMineral = await _mineralRepository.GetByNameAsync(mineral.Name);
            if (existingMineral != null)
            {
                return false;
            }

            await _mineralRepository.AddAsync(mineral);
            return true;
        }

        public async Task<bool> UpdateMineralAsync(int id, Mineral mineral)
        {
            var existingMineral = await _mineralRepository.GetByIdAsync(id);

            if (existingMineral == null)
            {
                return false;
            }

            if (existingMineral.Id != mineral.Id)
            {
                return false;
            }

            existingMineral.Name = mineral.Name;
            existingMineral.Information = mineral.Information;
            existingMineral.Formula = mineral.Formula;
            existingMineral.Properties = mineral.Properties;
            existingMineral.Locations = mineral.Locations;

            await _mineralRepository.UpdateAsync(existingMineral);
            return true;
        }

        public async Task DeleteMineralAsync(int id)
        {
            await _mineralRepository.DeleteAsync(id);
        }

        public async Task<List<Mineral>> SearchMineralsAsync(string query)
        {
            var minerals = await _mineralRepository.SearchMineralsAsync(query);
            return minerals;
        }
    }
}
