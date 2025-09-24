using System.Data.Entity;

namespace PurrfectBlog.Models
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<BlogPost>()
                .Property(b => b.Content)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}