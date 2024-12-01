﻿namespace Api.Controllers
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

        // GET: api/Collection
        [HttpGet]
        public async Task<ActionResult<List<Collection>>> GetCollections()
        {
            var collections = await _collectionService.GetAllCollectionsAsync();
            return Ok(collections);
        }

        // GET: api/Collection/5
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

        // POST: api/Collection
        [HttpPost]
        public async Task<ActionResult> CreateCollection(Collection collection)
        {
            await _collectionService.CreateCollectionAsync(collection);
            return CreatedAtAction(nameof(GetCollection), new { id = collection.Id }, collection);
        }

        // PUT: api/Collection/5
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

        // DELETE: api/Collection/5
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
