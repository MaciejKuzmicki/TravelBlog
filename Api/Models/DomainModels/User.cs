using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.DomainModels
{
    public class User : IdentityUser
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Image {  get; set; }

        public ICollection<User> ObservedUsers { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
