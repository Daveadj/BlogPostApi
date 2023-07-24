using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Content { get; set; }
        public int BlogId { get; set; }

        [ForeignKey(nameof(BlogId))]
        public Blog? Blog { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}