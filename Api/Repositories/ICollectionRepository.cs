namespace Api.Repositories
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICollectionRepository
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
    }
}
