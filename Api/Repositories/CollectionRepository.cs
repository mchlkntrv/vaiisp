namespace Api.Repositories
{
    using Models;
    using Api.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class CollectionRepository(ApplicationDbContext context) : ICollectionRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Collection>> GetAllCollectionsAsync()
        {
            return await _context.Collections.ToListAsync();
        }

        public async Task<Collection> GetCollectionByIdAsync(int id)
        {
            return await _context.Collections
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateCollectionAsync(Collection collection)
        {
            _context.Collections.Add(collection);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCollectionAsync(Collection collection)
        {
            _context.Collections.Update(collection);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCollectionAsync(int id)
        {
            var collection = await _context.Collections
                .FirstOrDefaultAsync(c => c.Id == id);

            if (collection != null)
            {
                _context.Collections.Remove(collection);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Collection>> GetCollectionsByUserIdAsync(int userId)
        {
            return await _context.Collections
                .Where(c => c.OwnerId == userId)
                .ToListAsync();
        }

        public async Task<List<CollectionItem>> GetItemsInCollectionAsync(int collectionId)
        {
            return await _context.CollectionItems
                .Where(ci => ci.CollectionId == collectionId)
                .ToListAsync();
        }

        public async Task<List<Mineral>> GetMineralsInCollectionAsync(int collectionId)
        {
            return await _context.CollectionItems
        .Where(ci => ci.CollectionId == collectionId)
        .Join(_context.Minerals,
              ci => ci.MineralId,
              m => m.Id,
              (ci, m) => m)
        .ToListAsync();
        }

        public async Task<bool> AddItemToCollectionAsync(int collectionId, int mineralId)
        {
            var newItem = new CollectionItem
            {
                CollectionId = collectionId,
                MineralId = mineralId
            };

            await _context.CollectionItems.AddAsync(newItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
