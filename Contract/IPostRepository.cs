using Entities.Models;

namespace Contract
{
    public interface IPostRepository
    {
        Task<ICollection<Post>> GetAllPost(int blogId);

        Task<Post> GetPostById(int postId);

        Task<Post> CreatePost(int blogId, Post post);

        Task Update();

        Task Delete(Post post);
    }
}