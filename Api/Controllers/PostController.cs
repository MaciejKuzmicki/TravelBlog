using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllPosts()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet("{PostId:Guid}")]
        public async Task<IActionResult> getPostById(Guid PostId)
        {
            return Ok(_postService.GetPostById(PostId));
        }

        [HttpDelete("{PostId:Guid}")]
        public async Task<IActionResult> deletePost(Guid PostId)
        {
            await _postService.DeletePost(PostId);
            return Ok();
        }
    } 
}
