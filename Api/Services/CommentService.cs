using Api.Models;
using Api.Models.DomainModels;

namespace Api.Services
{
    public class CommentService : ICommentService
    {
        private readonly TravelDataContext _context;

        public CommentService(TravelDataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<Comment> DeleteComment(Guid id)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
    }
}
