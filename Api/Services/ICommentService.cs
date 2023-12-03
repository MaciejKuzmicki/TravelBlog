using Api.Models.DomainModels;

namespace Api.Services
{
    public interface ICommentService
    {
        Task<Comment> DeleteComment(Guid id);

    }
}
