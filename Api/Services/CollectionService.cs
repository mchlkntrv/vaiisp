namespace Api.Services
{
    using Api.Repositories;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICollectionService
    {
        Task<List<Collection>> GetAllCollectionsAsync();
        Task<Collection> GetCollectionByIdAsync(int id);
        Task CreateCollectionAsync(Collection collection);
        Task UpdateCollectionAsync(Collection collection);
        Task DeleteCollectionAsync(int id);
        Task<IEnumerable<Collection>> GetCollectionsByUserIdAsync(int userId);
        Task<List<CollectionItem>> GetItemsInCollectionAsync(int collectionId);
        Task<List<Mineral>> GetMineralsInCollectionAsync(int collectionId);
        Task<bool> AddItemToCollectionAsync(int collectionId, int mineralId);
        Task<bool> DeleteCollectionItemAsync(int collectionItemId);
    }

    public class CollectionService : ICollectionService
    {
        private readonly ICollectionRepository _collectionRepository;

        public CollectionService(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public async Task<List<Collection>> GetAllCollectionsAsync()
        {
            return await _collectionRepository.GetAllCollectionsAsync();
        }

        public async Task<Collection> GetCollectionByIdAsync(int id)
        {
            return await _collectionRepository.GetCollectionByIdAsync(id);
        }

        public async Task CreateCollectionAsync(Collection collection)
        {
            await _collectionRepository.CreateCollectionAsync(collection);
        }

        public async Task UpdateCollectionAsync(Collection collection)
        {
            await _collectionRepository.UpdateCollectionAsync(collection);
        }

        public async Task DeleteCollectionAsync(int id)
        {
            await _collectionRepository.DeleteCollectionAsync(id);
        }

        public async Task<IEnumerable<Collection>> GetCollectionsByUserIdAsync(int userId)
        {
            return await _collectionRepository.GetCollectionsByUserIdAsync(userId);
        }

        public async Task<List<CollectionItem>> GetItemsInCollectionAsync(int collectionId)
        {
            return await _collectionRepository.GetItemsInCollectionAsync(collectionId);
        }

        public async Task<List<Mineral>> GetMineralsInCollectionAsync(int collectionId)
        {
            return await _collectionRepository.GetMineralsInCollectionAsync(collectionId);
        }

        public async Task<bool> AddItemToCollectionAsync(int collectionId, int mineralId)
        {
            return await _collectionRepository.AddItemToCollectionAsync(collectionId, mineralId);
        }

        public async Task<bool> DeleteCollectionItemAsync(int collectionItemId)
        {
            return await _collectionRepository.DeleteCollectionItemAsync(collectionItemId);
        }
    }
}
