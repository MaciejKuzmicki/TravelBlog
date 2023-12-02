using Api.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class TravelDataContext : DbContext
    {
        public TravelDataContext(DbContextOptions<TravelDataContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
        .HasOne(p => p.Author)
        .WithMany(u => u.Posts)
        .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<Comment>()
        .HasOne(c => c.Author)
        .WithMany(u => u.Comments)
        .HasForeignKey(c => c.AuthorId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);

            modelBuilder.UseSerialColumns();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
