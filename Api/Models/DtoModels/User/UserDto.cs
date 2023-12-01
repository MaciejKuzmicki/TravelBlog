using Api.Models.DomainModels;

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

        public ICollection<User> ObservedUsers { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<DomainModels.Post> Posts { get; set; }
    }
}
