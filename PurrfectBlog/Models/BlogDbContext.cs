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
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<BlogPost>()
                .Property(b => b.Content)
                .IsRequired()
                .HasMaxLength(5000);

            modelBuilder.Entity<BlogPost>()
                .Property(b => b.Category)
                .HasMaxLength(50);

            base.OnModelCreating(modelBuilder);
        }
    }
}