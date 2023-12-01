﻿using System.ComponentModel.DataAnnotations;

namespace Api.Models.DomainModels
{
    public class Comment
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }

        public Guid PostId { get; set; }
        public Guid AuthorId { get; set; }
    }
}