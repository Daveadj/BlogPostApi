using Entities.Dto;
using Entities.Models;

namespace BlogPostApi.Mappings
{
    public static class BlogManualMapper
    {
        public static BlogDetailsDto MapToBlogDetails(this Blog blog)
        {
            var blogDetails = new BlogDetailsDto
            {
                Id = blog.Id,
                Description = blog.Description,
                Name = blog.Name,
                CreatedOn = blog.CreatedOn,
            };

            return blogDetails;
        }

        public static Blog MapToBlog(this BlogDto blogDto)
        {
            var newBlog = new Blog
            {
                Name = blogDto.Name,
                Description = blogDto.Description,
            };
            return newBlog;
        }

        public static List<BlogDetailsDto> MapToBlogDetailDto(this List<Blog> blogList)
        {
            var newBlogList = new List<BlogDetailsDto>();
            foreach (var blog in blogList)
            {
                var blogDetails = new BlogDetailsDto
                {
                    Id = blog.Id,
                    Description = blog.Description,
                    Name = blog.Name,
                    CreatedOn = blog.CreatedOn,
                };
                newBlogList.Add(blogDetails);
            }
            return newBlogList;
        }
    }
}