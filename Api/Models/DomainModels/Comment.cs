using System.ComponentModel.DataAnnotations;

namespace Api.Models.DomainModels
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Post Post { get; set; }
        public User Author { get; set; }
    }
}