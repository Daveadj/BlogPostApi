using Contract;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogPostDbContext _dbContext;

        public PostRepository(BlogPostDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> CreatePost(int blogId, Post post)
        {
            post.BlogId = blogId;
            post.DateCreated = DateTime.Now;
            post.LastModified = DateTime.Now;
            _dbContext.Posts.Add(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task Delete(Post post)
        {
            _dbContext.Posts.Remove(post);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Post>> GetAllPost(int blogId)
        {
            var posts = await _dbContext.Posts
                .Where(p => p.BlogId == blogId)
                .ToListAsync();
            return posts;
        }

        public async Task<Post> GetPostById(int postId)
        {
            var post = await _dbContext.Posts
                .FirstOrDefaultAsync(p => p.Id == postId);

            return post;
        }

        public async Task Update()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}