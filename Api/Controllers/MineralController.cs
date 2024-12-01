using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MineralController(IMineralService mineralService) : ControllerBase
    {
        private readonly IMineralService _mineralService = mineralService;

        // GET: api/mineral
        [HttpGet]
        public async Task<ActionResult<List<Mineral>>> GetAllMinerals()
        {
            var minerals = await _mineralService.GetAllMineralsAsync();
            return Ok(minerals);
        }
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

        // POST: api/mineral
        [HttpPost]
        public async Task<ActionResult<Mineral>> CreateMineral(Mineral mineral)
        {
            if (mineral == null)
            {
                return BadRequest();
            }

            await _mineralService.CreateMineralAsync(mineral);

            return CreatedAtAction(nameof(GetMineralById), new { id = mineral.Id }, mineral);
        }

        // PUT: api/mineral/5
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

            await _mineralService.UpdateMineralAsync(mineral);
            return NoContent();
        }

        // DELETE: api/mineral/5
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
    }
}
