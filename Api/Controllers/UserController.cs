using Api.Models.DomainModels;
using Api.Models.DtoModels;
using Api.Models.DtoModels.Comment;
using Api.Models.DtoModels.Post;
using Api.Models.DtoModels.User;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] UserLoginDto userDto)
        {
            var response = await _userService.Login(userDto.Email, userDto.Password);
            if (response == null)
            {
                return BadRequest();
            }
            
            return Ok(response.Token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] UserRegisterDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Email = userDto.Email,
                RegistrationDate = DateTime.UtcNow,
                Comments = new List<Comment>(),
                ObservedUsers = new List<User>(),
                Posts = new List<Post>(),
                Image = userDto.Image,
                Token = ""
            };
            await _userService.Register(user, userDto.Password);
            
            
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

            return Created("Created", result);

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getAllUsers()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{UserId:Guid}")]
        public async Task<IActionResult> getUserById(Guid UserId)
        {
            return Ok(_userService.GetUserById(UserId));
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
                DateTime = DateTime.UtcNow
            };

            await _userService.CreatePost(post, UserId);

            var result = new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                Comments = post.Comments,
                DateTime = post.DateTime,
                AuthorId = post.AuthorId,
                Images = post.Images
            };
            return Created("Created", result);
        }

        [HttpPost("{UserId:Guid}/posts/{PostId:Guid}/comments")]
        public async Task<IActionResult> addComment(Guid PostId, Guid UserId, CreateCommentDto newComment)
        {
            var comment = new Comment
            {
                Description = newComment.Description,
            };
            await _userService.CreateComment(comment, UserId, PostId);
            var result = new CommentDto
            {
                Id = comment.Id,
                AuthorId = comment.AuthorId,
                PostId = comment.PostId,
                Description = comment.Description
            };
            return Created("Created", result);
        }

    }
}
