namespace Api.Controllers
{
    using Api.Services;
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController(ICollectionService collectionService) : ControllerBase
    {
        private readonly ICollectionService _collectionService = collectionService;

        // GET: api/collection
        [HttpGet]
        public async Task<ActionResult<List<Collection>>> GetCollections()
        {
            var collections = await _collectionService.GetAllCollectionsAsync();
            return Ok(collections);
        }

        // GET: api/collection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Collection>> GetCollection(int id)
        {
            var collection = await _collectionService.GetCollectionByIdAsync(id);

            if (collection == null)
            {
                return NotFound();
            }

            return Ok(collection);
        }

        // GET: api/collection/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCollectionsByUserId(int userId)
        {
            var collections = await _collectionService.GetCollectionsByUserIdAsync(userId);

            if (collections == null || !collections.Any())
            {
                return NotFound("Uzivatel nema ziadne kolekcie.");
            }

            return Ok(collections);
        }

        // POST: api/collection
        [HttpPost]
        public async Task<ActionResult> CreateCollection(Collection collection)
        {
            await _collectionService.CreateCollectionAsync(collection);
            return CreatedAtAction(nameof(GetCollection), new { id = collection.Id }, collection);
        }

        // PUT: api/collection/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCollection(int id, Collection collection)
        {
            if (id != collection.Id)
            {
                return BadRequest();
            }

            await _collectionService.UpdateCollectionAsync(collection);
            return NoContent();
        }

        // DELETE: api/collection/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCollection(int id)
        {
            var collection = await _collectionService.GetCollectionByIdAsync(id);
            if (collection == null)
            {
                return NotFound();
            }

            await _collectionService.DeleteCollectionAsync(id);
            return NoContent();
        }

        // GET: api/collection/{collectionId}/items
        [HttpGet("{collectionId}/items")]
        public async Task<ActionResult<List<CollectionItem>>> GetItemsInCollection(int collectionId)
        {
            var items = await _collectionService.GetItemsInCollectionAsync(collectionId);

            if (items == null || !items.Any())
            {
                return NotFound("Kolekcia neobsahuje ziadne itemy.");
            }

            return Ok(items);
        }

        // GET: api/collection/{collectionId}/minerals
        [HttpGet("{collectionId}/minerals")]
        public async Task<ActionResult<List<CollectionItem>>> GetMineralsInCollection(int collectionId)
        {
            var minerals = await _collectionService.GetMineralsInCollectionAsync(collectionId);

            if (minerals == null || !minerals.Any())
            {
                return NotFound("Kolekcia neobsahuje ziadne mineraly.");
            }

            return Ok(minerals);
        }

        //// POST: api/collection/{collectionId}/items/{mineralId}
        //[HttpPost("{collectionId}/items/{mineralId}")]
        //public async Task<ActionResult> AddItemToCollection(int collectionId, int mineralId)
        //{
        //    var success = await _collectionService.AddItemToCollectionAsync(collectionId, mineralId);

        //    if (!success)
        //    {
        //        return BadRequest("Nepodarilo sa pridat item do kolekcie.");
        //    }

        //    return Ok("Item bol pridany do kolekcie.");
        //}

        // POST: api/collection/{collectionId}/items/{mineralId}
        [HttpPost("{collectionId}/items/{mineralId}")]
        public async Task<ActionResult> AddItemToCollection(int collectionId, int mineralId)
        {
            var success = await _collectionService.AddItemToCollectionAsync(collectionId, mineralId);

            if (!success)
            {
                return BadRequest("Nepodarilo sa pridat item do kolekcie.");
            }

            return Ok("Item bol pridany do kolekcie.");
        }

        // DELETE: api/collection/items/{collectionItemId}
        [HttpDelete("items/{collectionItemId}")]
        public async Task<IActionResult> DeleteCollectionItem(int collectionItemId)
        {
            var success = await _collectionService.DeleteCollectionItemAsync(collectionItemId);

            if (!success)
            {
                return NotFound($"CollectionItem ID {collectionItemId} nebol najdeny.");
            }

            return NoContent();
        }

    }
}
