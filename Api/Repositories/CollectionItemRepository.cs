using Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public interface ICollectionItemRepository
    {
        Task<List<CollectionItem>> GetAllCollectionItemsAsync();
        Task<CollectionItem> GetCollectionItemAsync(int collectionItemId);
        Task CreateCollectionItemAsync(CollectionItem collectionItem);
        Task DeleteCollectionItemAsync(int collectionId, int mineralId);
    }

    public class CollectionItemRepository : ICollectionItemRepository
    {
        private readonly ApplicationDbContext _context;

        public CollectionItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CollectionItem>> GetAllCollectionItemsAsync()
        {
            return await _context.CollectionItems.ToListAsync();
        }

        public async Task<CollectionItem> GetCollectionItemAsync(int collectionItemId)
        {
            return await _context.CollectionItems
                .FirstOrDefaultAsync(ci => ci.Id == collectionItemId);
        }

        public async Task CreateCollectionItemAsync(CollectionItem collectionItem)
        {
            _context.CollectionItems.Add(collectionItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCollectionItemAsync(int collectionId, int mineralId)
        {
            var collectionItem = await _context.CollectionItems
                .FirstOrDefaultAsync(ci => ci.CollectionId == collectionId && ci.MineralId == mineralId);

            if (collectionItem != null)
            {
                _context.CollectionItems.Remove(collectionItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
