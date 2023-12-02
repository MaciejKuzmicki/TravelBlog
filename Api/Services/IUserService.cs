using Api.Models.DomainModels;
using Api.Models.DtoModels;

namespace Api.Services
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> Login(User user);
        Task<List<User>> GetAll();
        Task<Post> CreatePost(Post post, Guid UserId);
        Task<User> GetUserById(Guid id);
        Task<Comment> CreateComment(Comment comment, Guid UserId, Guid PostId);
        Task<List<Comment>> GetComments();
    }
}
