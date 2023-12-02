using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.DomainModels
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public Guid PostId { get; set; }
        [ForeignKey("AuthorId")]
        public User Author { get; set; }
        public Guid AuthorId { get; set; } 
    }
}