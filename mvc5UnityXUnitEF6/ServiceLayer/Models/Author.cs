using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public class AuthorVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<BookVM> Books { get; set; }
    }
}
