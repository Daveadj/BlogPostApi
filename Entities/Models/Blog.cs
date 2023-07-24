﻿namespace Entities.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Post> Post { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}