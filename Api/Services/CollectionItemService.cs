namespace Api.Services
{
    using Api.Repositories;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CollectionItemService(ICollectionItemRepository collectionItemRepository) : ICollectionItemService
    {
        private readonly ICollectionItemRepository _collectionItemRepository = collectionItemRepository;

        public async Task<List<CollectionItem>> GetAllCollectionItemsAsync()
        {
            return await _collectionItemRepository.GetAllCollectionItemsAsync();
        }

        public async Task<CollectionItem> GetCollectionItemAsync(int collectionId, int mineralId)
        {
            return await _collectionItemRepository.GetCollectionItemAsync(collectionId, mineralId);
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
