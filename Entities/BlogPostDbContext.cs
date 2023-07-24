using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class BlogPostDbContext : DbContext
    {
        public BlogPostDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}