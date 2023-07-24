using BlogPostApi.Mappings;
using Contract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostApi.Controllers
{
    [Route("api/blog/{blogId}/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IBlogRepository _blogRepository;

        public PostController(IPostRepository postRepository, IBlogRepository blogRepository)
        {
            _postRepository = postRepository;
            _blogRepository = blogRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(int blogId, PostDto postToCreate)
        {
            if (postToCreate == null)
            {
                return BadRequest();
            }
            var blogEntity = await _blogRepository.GetBlogById(blogId);
            if (blogEntity == null)
            {
                return BadRequest();
            }
            var postEntity = postToCreate.MapToPost();

            await _postRepository.CreatePost(blogId, postEntity);
            var postDetails = postEntity.MapToPostDetails();
            return Ok(postDetails);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPost(int blogId)
        {
            if (blogId == null)
            {
                return BadRequest();
            }
            var posts = await _postRepository.GetAllPost(blogId);
            if (posts == null)
            {
                return BadRequest();
            }
            var postDetailsToReturn = posts.ToList().MapToPostDetailDto();
            return Ok(postDetailsToReturn);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var postEntity = await _postRepository.GetPostById(postId);
            var postDetailsToReturn = postEntity.MapToPostDetails();

            return Ok(postDetailsToReturn);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var postEntity = await _postRepository.GetPostById(postId);
            if (postEntity == null)
            {
                return BadRequest();
            }
            await _postRepository.Delete(postEntity);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePost(int postId, PostDto postToUpdate)
        {
            if (postToUpdate == null)
            {
                return BadRequest();
            }
            var postEntity = await _postRepository.GetPostById(postId);
            if (postEntity == null)
            {
                return BadRequest();
            }
            postEntity.Name = postToUpdate.Name;
            postEntity.Content = postToUpdate.Content;
            postEntity.LastModified = DateTime.Now;

            await _postRepository.Update();
            return Ok();
        }
    }
}