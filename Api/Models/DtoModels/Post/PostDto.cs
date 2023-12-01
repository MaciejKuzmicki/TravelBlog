using Api.Models.DomainModels;

namespace Api.Models.DtoModels.Post
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        public Guid AuthorId { get; set; }

        public List<String> Images { get; set; }
        public ICollection<DomainModels.Comment> Comments { get; set; }
    }
}
