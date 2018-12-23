using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class BookShop
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; }
    }
}
