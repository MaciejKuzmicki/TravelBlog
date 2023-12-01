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

        public async Task<User> register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<List<User>> getAll()
        {
            return _context.Users.Include(b=>b.Posts).ToList();
        }

        public async Task<Post> createPost(Post post)
        {
            await _context.Posts.AddAsync(post);
            var user = _context.Users.Include(b=>b.Posts).FirstOrDefault(x=> x.Id == post.AuthorId);
            user.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<User> getUserById(Guid id)
        {
            return _context.Users.Include(b=>b.Posts).FirstOrDefault(x => x.Id == id);
        }

        public Task<Comment> createComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
