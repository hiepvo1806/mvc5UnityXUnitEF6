using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Repo;

namespace ServiceLayer.Service
{
    public class BookShopService : BaseService<BookShopVM, BookShop>, IBookShopService
    {
        public BookShopService()
        {
            repo = new BookShopRepo();
        }
    }

    public interface IBookShopService : IBaseService<BookShopVM>
    {

    }
}
