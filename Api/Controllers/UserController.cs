using Api.Models.DomainModels;
using Api.Models.DtoModels;
using Api.Models.DtoModels.Post;
using Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> register(UserRegisterDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                HashedPassword = userDto.Password,
                RegistrationDate = DateTime.UtcNow,
                Comments = new List<Comment>(),
                ObservedUsers = new List<User>(),
                Posts = new List<Post>(),
                Image = userDto.Image
            };

            await _userService.Register(user);

            var result = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
                Comments = user.Comments,
                ObservedUsers = user.ObservedUsers,
                Posts = user.Posts,
                Image = user.Image
            };

            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> getAllUsers()
        {
            return Ok(_userService.getAll());
        }

        

        [HttpPost("{UserId:Guid}/posts")]
        public async Task<IActionResult> addPost(Guid UserId, CreatePostDto newPost)
        {
            var post = new Post
            {
                Title = newPost.Title,
                Description = newPost.Description,
                Images = newPost.Images,
                Comments = new List<Comment>(),
                DateTime = DateTime.UtcNow,
                AuthorId = UserId
            };

            await _userService.createPost(post);
            return Ok(post);
        }

        [HttpPost("{UserId:int}/posts/{PostId:int}/comments")]
        public async Task<IActionResult> addComment(int PostId, int UserId)
        {
            return Ok();
        }

    }
}
