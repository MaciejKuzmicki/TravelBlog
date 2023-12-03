using Api.Models;
using Api.Models.DomainModels;
using Api.Models.DtoModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly TravelDataContext _context;

        public UserService(TravelDataContext context)
        {
            _context = context;
        }

        public Task<User> Login(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<List<User>> GetAll()
        {
            return _context.Users.Include(b=>b.Posts).ToList();
        }

        public async Task<Post> CreatePost(Post post, Guid UserId)
        {
            var user = _context.Users.Include(b=>b.Posts).FirstOrDefault(x=>x.Id == UserId);
            post.Author = user;
            post.AuthorId = UserId; 
            user.Posts.Add(post);
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<User> GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Comment> CreateComment(Comment comment, Guid UserId, Guid PostId)
        {
            var user = _context.Users.Include(b=>b.Comments).FirstOrDefault(x => x.Id == UserId);
            var post = _context.Posts.Include(b=>b.Comments).FirstOrDefault(x => x.Id == PostId);
            user.Comments.Add(comment);
            post.Comments.Add(comment);
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetComments()
        {
            return _context.Comments.ToList();
        }
    }
}
