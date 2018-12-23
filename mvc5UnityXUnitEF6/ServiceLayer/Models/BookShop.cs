using System.Collections.Generic;

namespace ServiceLayer.Models
{
    public class BookShopVM
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public List<BookVM> Books { get; set; }
    }
}
