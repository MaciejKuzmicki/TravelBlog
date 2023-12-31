﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models.DomainModels
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        [ForeignKey("AuthorId")]
        public User Author { get; set; }
        public Guid AuthorId { get; set; }

        public List<String> Images { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
