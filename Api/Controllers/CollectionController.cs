namespace Api.Controllers
{
    using Api.Services;
    using Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

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
    }
}
