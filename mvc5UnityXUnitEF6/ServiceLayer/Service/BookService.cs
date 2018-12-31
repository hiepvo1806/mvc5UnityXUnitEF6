using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.Repo;
using AutoMapper;

namespace ServiceLayer.Service
{
    public class BookService : BaseService<BookVM, Book>, IBookService
    {

        public BookService(IMapper mapper) : base(mapper,(new BookRepo()))
        {
            
        }
    }

    public interface IBookService : IBaseService<BookVM>
    {

    }
}
