﻿using Api.Models.DomainModels;

namespace Api.Models.DtoModels
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }

        public ICollection<DomainModels.User> ObservedUsers { get; set; }
        public ICollection<DomainModels.Comment> Comments { get; set; }
        public ICollection<DomainModels.Post> Posts { get; set; }
    }
}
