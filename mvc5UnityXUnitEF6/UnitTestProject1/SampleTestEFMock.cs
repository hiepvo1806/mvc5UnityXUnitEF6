using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repo;
using Moq;
using ServiceLayer;
using ServiceLayer.Models;
using ServiceLayer.Service;
using UnitTestProject1.Helper;
using UnitTestProject1.Model;
using Xunit;
using System.Linq;

namespace UnitTestProject1
{
    public class SampleTestEFMock
    {
        protected IMapper _mapper { get; set; }
        public SampleTestEFMock()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceMapperProfile());
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void SampleEfTest()
        {
            var author = new Author()
            {
                Age = 123,
                Books = new List<Book>(),
                FirstName = "Just Mocked First Name",
                Id = 123,
                LastName = "Just Mocked Last Name"
            };

            var dataSource = new List<Author>()
            {
                author
            }; //<-- this will hold data
           
            var mockSet = new MockDbSet<Author>(dataSource);
            var mockContext = new Mock<BookstoreContext>();

            mockContext.Setup(c => c.Set<Author>()).Returns(mockSet.Object);
            IAuthorRepo authorRepo = new AuthorRepo(mockContext.Object);
            IUnitOfWork uow = new UnitOfWork(mockContext.Object);
            IUnitOfWorkService uowService = new UnitOfWorkService(uow);
            IAuthorService service = new AuthorService(_mapper,authorRepo);
            //ACT
            service.Create(new AuthorVM()
            {
                FirstName = "hiep",
                Books = null,
                Id = 12,
                LastName = "Vo",
                Age = 28
            });
            uowService.Commit();
            
            // ASSERT
            mockSet.Verify(u => u.Add(It.IsAny<Author>()), Times.Once());
            Assert.Contains(dataSource, x =>x.FirstName == "hiep"); //<-- shows mock actually added item
        }
    }
}
