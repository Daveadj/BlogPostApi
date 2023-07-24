using Entities.Models;

namespace Contract
{
    public interface IBlogRepository
    {
        Task<ICollection<Blog>> GetAllBlogs();

        Task<Blog> GetBlogById(int id);

        Task<Blog> Create(Blog blog);

        Task Update();

        Task Delete(Blog blog);
    }
}