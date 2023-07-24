using Entities.Dto;
using Entities.Models;

namespace BlogPostApi.Mappings
{
    public static class PostManualMapper
    {
        public static PostDetailsDto MapToPostDetails(this Post post)
        {
            var postDetails = new PostDetailsDto
            {
                Id = post.Id,
                Name = post.Name,
                Content = post.Content,
                BlogId = post.BlogId,
                DateCreated = post.DateCreated,
                LastModified = post.LastModified,
            };
            return postDetails;
        }

        public static Post MapToPost(this PostDto postDto)
        {
            var newPost = new Post
            {
                Name = postDto.Name,
                Content = postDto.Content,
            };
            return newPost;
        }

        public static List<PostDetailsDto> MapToPostDetailDto(this List<Post> postList)
        {
            var newPostList = new List<PostDetailsDto>();
            foreach (var post in postList)
            {
                var postDetails = new PostDetailsDto
                {
                    Id = post.Id,
                    Name = post.Name,
                    Content = post.Content,
                    BlogId = post.BlogId,
                    DateCreated = post.DateCreated,
                    LastModified = post.LastModified,
                };
                newPostList.Add(postDetails);
            }
            return newPostList;
        }
    }
}