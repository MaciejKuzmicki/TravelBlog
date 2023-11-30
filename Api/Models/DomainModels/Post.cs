using System.ComponentModel.DataAnnotations;

namespace Api.Models.DomainModels
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        public User Author { get; set; }

        public List<String> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
