namespace ServiceLayer.Models
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public AuthorVM BookAuthor { get; set; }
    }
}
