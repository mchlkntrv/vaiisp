using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(ICommentService commentService) : ControllerBase
    {
        private readonly ICommentService _commentService = commentService;

        // GET: api/comments/mineral/{mineralId}
        [HttpGet("mineral/{mineralId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentsByMineralId(int mineralId)
        {
            var comments = await _commentService.GetCommentsByMineralIdAsync(mineralId);
            if (comments == null || comments.Count() == 0)
            {
                return NotFound();
            }
            return Ok(comments);
        }

        // POST: api/comments
        [HttpPost]
        public async Task<ActionResult<Comment>> AddComment(Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            var createdComment = await _commentService.AddCommentAsync(comment);
            return Ok(createdComment);
        }

        // DELETE: api/comments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.DeleteCommentAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
