namespace Api.Controllers
{
    using Api.Services;
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionItemController(ICollectionItemService collectionItemService) : ControllerBase
    {
        private readonly ICollectionItemService _collectionItemService = collectionItemService;

        // GET: api/CollectionItem
        [HttpGet]
        public async Task<ActionResult<List<CollectionItem>>> GetCollectionItems()
        {
            var collectionItems = await _collectionItemService.GetAllCollectionItemsAsync();
            return Ok(collectionItems);
        }

        // GET: api/CollectionItem/5/10
        [HttpGet("{collectionId}/{mineralId}")]
        public async Task<ActionResult<CollectionItem>> GetCollectionItem(int collectionId, int mineralId)
        {
            var collectionItem = await _collectionItemService.GetCollectionItemAsync(collectionId, mineralId);

            if (collectionItem == null)
            {
                return NotFound();
            }

            return Ok(collectionItem);
        }

        // POST: api/CollectionItem
        [HttpPost]
        public async Task<ActionResult> CreateCollectionItem(CollectionItem collectionItem)
        {
            await _collectionItemService.CreateCollectionItemAsync(collectionItem);
            return CreatedAtAction(nameof(GetCollectionItem), new { collectionId = collectionItem.CollectionId, mineralId = collectionItem.MineralId }, collectionItem);
        }

        //// DELETE: api/CollectionItem/5/10
        //[HttpDelete("{collectionId}/{mineralId}")]
        //public async Task<ActionResult> DeleteCollectionItem(int collectionId, int mineralId)
        //{
        //    var collectionItem = await _collectionItemService.GetCollectionItemAsync(collectionId, mineralId);
        //    if (collectionItem == null)
        //    {
        //        return NotFound();
        //    }

        //    await _collectionItemService.DeleteCollectionItemAsync(collectionId, mineralId);
        //    return NoContent();
        //}
    }
}
