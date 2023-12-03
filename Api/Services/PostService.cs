using Api.Models;
using Api.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class PostService : IPostService
    {
        private readonly TravelDataContext _context;

        public PostService(TravelDataContext context)
        {
            _context = context;
        }

        public async Task<Post> DeletePost(Guid id) // pomyslec co z komentarzami sie dzieje, bo sa przypisywane do posta i do usera moze jakas petla usuwajaca ?
        {
            var post = _context.Posts.FirstOrDefault(x=> x.Id == id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<Post> GetPostById(Guid id)
        {
            var post = _context.Posts.Include(x=>x.Author).Include(x=>x.Comments).FirstOrDefault(x=>x.Id == id);
            return post;
        }

        public async Task<List<Post>> GetPosts()
        {
            return _context.Posts.ToList();
        }
    }
}
