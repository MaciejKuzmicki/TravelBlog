using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpDelete]
        public async Task<IActionResult> deleteComment(Guid CommentId)
        {
            await _commentService.DeleteComment(CommentId);
            return NoContent();
        }
    }
}
