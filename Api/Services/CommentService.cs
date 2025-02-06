using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Repositories;

namespace Api.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsByMineralIdAsync(int mineralId);
        Task<Comment> AddCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(int id);
    }

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByMineralIdAsync(int mineralId)
        {
            return await _commentRepository.GetCommentsByMineralIdAsync(mineralId);
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            return await _commentRepository.AddCommentAsync(comment);
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            return await _commentRepository.DeleteCommentAsync(id);
        }
    }
}
