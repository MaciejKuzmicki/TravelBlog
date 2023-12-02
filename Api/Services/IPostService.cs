using Api.Models.DomainModels;

namespace Api.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPosts();
        Task<Post> GetPostById(Guid id);
        Task<Post> DeletePost(Guid id);
    }
}
