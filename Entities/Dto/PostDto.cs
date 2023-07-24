namespace Entities.Dto
{
    public class PostDto
    {
        public string? Name { get; set; }

        public string? Content { get; set; }
    }

    public class PostDetailsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Content { get; set; }
        public int BlogId { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}