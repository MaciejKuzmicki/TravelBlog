using Api.Models.DomainModels;
using Api.Models.DtoModels;

namespace Api.Services
{
    public interface IUserService
    {
        Task<User> Register(User user);
        Task<User> Login(User user);
        Task<List<User>> getAll();
        Task<Post> createPost(Post post);
        Task<User> getUserById(Guid id);
    }
}
