﻿using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MineralController(IMineralService mineralService) : ControllerBase
    {
        private readonly IMineralService _mineralService = mineralService;

        // GET: api/minerals
        [HttpGet]
        public async Task<ActionResult<List<Mineral>>> GetAllMinerals()
        {
            var minerals = await _mineralService.GetAllMineralsAsync();
            return Ok(minerals);
        }

        // GET: api/minerals/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Mineral>> GetMineralById(int id)
        {
            var mineral = await _mineralService.GetMineralByIdAsync(id);
            if (mineral == null)
            {
                return NotFound();
            }

            return Ok(mineral);
        }

        // POST: api/minerals
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<Mineral>> AddMineral(Mineral mineral)
        {
            if (mineral == null)
            {
                return BadRequest();
            }

            var result = await _mineralService.AddMineralAsync(mineral);
            if (!result)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetMineralById), new { id = mineral.Id }, mineral);
        }

        // PUT: api/minerals/{id}
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMineral(int id, Mineral mineral)
        {
            if (id != mineral.Id)
            {
                return BadRequest();
            }

            var existingMineral = await _mineralService.GetMineralByIdAsync(id);
            if (existingMineral == null)
            {
                return NotFound();
            }

            await _mineralService.UpdateMineralAsync(id, mineral);
            return NoContent();
        }

        // DELETE: api/minerals/{id}
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMineral(int id)
        {
            var mineral = await _mineralService.GetMineralByIdAsync(id);
            if (mineral == null)
            {
                return NotFound();
            }

            await _mineralService.DeleteMineralAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMinerals([FromQuery] string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return BadRequest("Vyhľadávací dopyt je prázdny.");
            }

            var minerals = await _mineralService.SearchMineralsAsync(query);

            if (minerals == null || minerals.Count() == 0)
            {
                return NotFound("Žiadne minerály neboli nájdené.");
            }

            return Ok(minerals);
        }
    }
}
