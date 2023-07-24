namespace Entities.Dto
{
    public class BlogDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class BlogDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}