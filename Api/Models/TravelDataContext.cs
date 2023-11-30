using Api.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class TravelDataContext : DbContext
    {
        public TravelDataContext(DbContextOptions<TravelDataContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.UseSerialColumns();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
