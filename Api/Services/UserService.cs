using Api.Models;
using Api.Models.DomainModels;
using Api.Models.DtoModels;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly TravelDataContext _context;

        public UserService(TravelDataContext context)
        {
            _context = context;
        }

        public Task<User> Login(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<List<User>> getAll()
        {
            return _context.Users.ToList();
        }
    }
}
