namespace Api.Services
{
    using Api.Repositories;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICollectionItemService
    {
        Task<List<CollectionItem>> GetAllCollectionItemsAsync();
        Task<CollectionItem> GetCollectionItemAsync(int collectionItemId);
        Task CreateCollectionItemAsync(CollectionItem collectionItem);
        Task DeleteCollectionItemAsync(int collectionId, int mineralId);
    }

    public class CollectionItemService : ICollectionItemService
    {
        private readonly ICollectionItemRepository _collectionItemRepository;

        public CollectionItemService(ICollectionItemRepository collectionItemRepository)
        {
            _collectionItemRepository = collectionItemRepository;
        }

        public async Task<List<CollectionItem>> GetAllCollectionItemsAsync()
        {
            return await _collectionItemRepository.GetAllCollectionItemsAsync();
        }

        public async Task<CollectionItem> GetCollectionItemAsync(int collectionItemId)
        {
            return await _collectionItemRepository.GetCollectionItemAsync(collectionItemId);
        }

        public async Task CreateCollectionItemAsync(CollectionItem collectionItem)
        {
            await _collectionItemRepository.CreateCollectionItemAsync(collectionItem);
        }

        public async Task DeleteCollectionItemAsync(int collectionId, int mineralId)
        {
            await _collectionItemRepository.DeleteCollectionItemAsync(collectionId, mineralId);
        }
    }
}
