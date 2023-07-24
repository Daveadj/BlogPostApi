using Contract;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogPostDbContext _dbContext;

        public BlogRepository(BlogPostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Blog> Create(Blog blog)
        {
            blog.CreatedOn = DateTime.Now;
            _dbContext.Blogs.Add(blog);
            await _dbContext.SaveChangesAsync();
            return blog;
        }

        public async Task Delete(Blog blog)
        {
            _dbContext.Blogs.Remove(blog);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Blog>> GetAllBlogs()
        {
            return await _dbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogById(int id)
        {
            var blog = await _dbContext.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            return blog;
        }

        public async Task Update()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}