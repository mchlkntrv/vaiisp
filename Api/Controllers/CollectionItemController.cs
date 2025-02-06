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

        // GET: api/CollectionItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionItem>> GetCollectionItem(int id)
        {
            var collectionItem = await _collectionItemService.GetCollectionItemAsync(id);

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
            return CreatedAtAction(nameof(GetCollectionItem), new { id = collectionItem.Id }, collectionItem);
        }
    }
}
