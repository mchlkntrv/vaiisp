namespace Api.Repositories
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICollectionItemRepository
    {
        Task<List<CollectionItem>> GetAllCollectionItemsAsync();
        Task<CollectionItem> GetCollectionItemAsync(int collectionId, int mineralId);
        Task CreateCollectionItemAsync(CollectionItem collectionItem);
        Task DeleteCollectionItemAsync(int collectionId, int mineralId);

    }
}
