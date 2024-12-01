namespace Api.Services
{
    using Api.Repositories;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CollectionService(ICollectionRepository collectionRepository) : ICollectionService
    {
        private readonly ICollectionRepository _collectionRepository = collectionRepository;

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
    }
}
