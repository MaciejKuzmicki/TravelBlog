using Api.Models.DomainModels;

namespace Api.Models.DtoModels.Post
{
    public class CreatePostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<String> Images { get; set; }
    }
}
