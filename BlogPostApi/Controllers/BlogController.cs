using BlogPostApi.Mappings;
using Contract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostApi.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogDto blogToCreate)
        {
            if (blogToCreate == null)
            {
                return BadRequest();
            }
            var blogEntity = blogToCreate.MapToBlog();

            await _blogRepository.Create(blogEntity);
            var blogDetails = blogEntity.MapToBlogDetails();
            return Ok(blogDetails);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlog()
        {
            var blogs = await _blogRepository.GetAllBlogs();
            var blogToReturn = blogs.ToList().MapToBlogDetailDto();
            return Ok(blogToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blogEntity = await _blogRepository.GetBlogById(id);
            if (blogEntity == null)
            {
                return BadRequest();
            }
            var blogDetailsToReturn = blogEntity.MapToBlogDetails();
            return Ok(blogDetailsToReturn);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(int id, BlogDto blogToUpdate)
        {
            if (blogToUpdate == null)
            {
                return BadRequest();
            }
            var blogEntity = await _blogRepository.GetBlogById(id);
            if (blogEntity == null)
            {
                return BadRequest();
            }
            blogEntity.Name = blogToUpdate.Name;
            blogEntity.Description = blogToUpdate.Description;

            await _blogRepository.Update();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blogEntity = await _blogRepository.GetBlogById(id);
            if (blogEntity == null)
            {
                return BadRequest();
            }
            await _blogRepository.Delete(blogEntity);
            return NoContent();
        }
    }
}