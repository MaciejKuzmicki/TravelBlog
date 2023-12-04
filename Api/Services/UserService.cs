using Api.Models;
using Api.Models.DomainModels;
using Api.Models.DtoModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly TravelDataContext _context;

        public UserService(TravelDataContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x=>x.Email == email);
            if(user == null)
            {
                return null;
            }
            else
            {
                var passwordHasher = new PasswordHasher<User>();
                var result = passwordHasher.VerifyHashedPassword(new User(), user.HashedPassword, password);
                if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
                {
                    user.Token = CreateToken(user);
                    return user;
                }
                else return null;
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
             {
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim(ClaimTypes.Email, user.Email),
                 new Claim(ClaimTypes.Surname, user.Surname)
             };

            SymmetricSecurityKey key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ReplaceThisWithYourStableKey1234567890ReplaceThisWithYourStableKey"));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                               claims: claims,
                               expires: DateTime.Now.AddDays(1),
                               signingCredentials: creds
                  );

            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenHandler;
        }

        public async Task<User> Register(User user, string password)
        {
            var passwordHasher = new PasswordHasher<User>();
            user.HashedPassword = passwordHasher.HashPassword(new User(), password);
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
