namespace Api.Repositories
{
    using Models;
    using Api.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CollectionItemRepository(ApplicationDbContext context) : ICollectionItemRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<CollectionItem>> GetAllCollectionItemsAsync()
        {
            return await _context.CollectionItems.ToListAsync();
        }

        public async Task<CollectionItem> GetCollectionItemAsync(int collectionId, int mineralId)
        {
            return await _context.CollectionItems
                .FirstOrDefaultAsync(ci => ci.CollectionId == collectionId && ci.MineralId == mineralId);
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
