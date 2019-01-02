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
        private readonly IMapper _mapper;
        private IAuthorRepo AuthorRepo { get; set; }
        private IUnitOfWork Uow { get; set; }

        private IUnitOfWorkService _uowService { get; set; }
        private IAuthorService _serviceUnderTest { get; set; }
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
            var setupResult =  Setup(null);
            var mockSet = setupResult.MockSet;
            var dataSource = setupResult.DataSource;
            //ACT
            _serviceUnderTest.Create(new AuthorVM()
            {
                FirstName = "Hiep",
                Books = null,
                Id = 12,
                LastName = "Vo",
                Age = 28
            });
            _uowService.Commit();
            
            // ASSERT
            mockSet.Verify(u => u.Add(It.IsAny<Author>()), Times.Once());
            Assert.Contains(dataSource, x =>x.FirstName == "Hiep"); //<-- shows mock actually added item
        }


        private MockSetupResult<Author> Setup(List<Author> inputDataSource)
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
            };
            if (inputDataSource != null)
                dataSource = dataSource.Concat(inputDataSource).ToList(); //<-- this will hold data
            var mockSet = new MockDbSet<Author>(dataSource);
            var mockContext = new Mock<BookstoreContext>();
            mockContext.Setup(c => c.Set<Author>()).Returns(mockSet.Object);
            AuthorRepo = new AuthorRepo(mockContext.Object);
            AuthorRepo = new AuthorRepo(mockContext.Object);
            Uow = new UnitOfWork(mockContext.Object);
            _uowService = new UnitOfWorkService(Uow);
            _serviceUnderTest = new AuthorService(_mapper, AuthorRepo);
            return new MockSetupResult<Author>
            {
                DataSource = dataSource,
                MockSet = mockSet
            };

        }
    }

    public class MockSetupResult<T> where T:class
    {
        public MockDbSet<T> MockSet { get; set; }
        public List<T> DataSource { get; set; }
    }
}
