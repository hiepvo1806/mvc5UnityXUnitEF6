namespace PresentationLayer.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Author BookAuthor { get; set; }
    }
}
