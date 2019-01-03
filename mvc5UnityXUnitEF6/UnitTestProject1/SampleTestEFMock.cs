using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repo;
using Moq;
using ServiceLayer;
using ServiceLayer.Models;
using ServiceLayer.Service;
using Xunit;
using UnitTestProject.Helper;
using UnitTestProject1.Model;

namespace UnitTestProject
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
        public void AddEFEntityThroughRepositoryShouldReturnTrue()
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

        [Fact]
        public void ComplexAddedAuthorByExposeDbContextTest()
        {
            //SETUP
            var setupResult = Setup(null);
            var mockSet = setupResult.MockSet;
            var dataSource = setupResult.DataSource;
            //ACT
            _serviceUnderTest.ComplexAddedAuthorByExposeDbContext(new AuthorVM()
            {
                FirstName = "Jeff",
                Books = null,
                Id = 12,
                LastName = "Vo",
                Age = 28
            });
            _uowService.Commit();

            // ASSERT
            mockSet.Verify(u => u.Add(It.IsAny<Author>()), Times.Once());
            Assert.Contains(dataSource, x => x.FirstName == "Jeff"); //<-- shows mock actually added item
        }

        [Fact]
        public void ServiceDetailShouldReturnTrue()
        {
            //SETUP
            var setupResult = Setup(null);
            var mockSet = setupResult.MockSet;
            var dataSource = setupResult.DataSource;
            //ACT
            var result = _serviceUnderTest.Details(123);

            //ASSERT
            Assert.NotNull(result);
        }

        [Fact]
        public void ServicEditShouldReturnTrue()
        {
            //SETUP
            var setupResult = Setup(null);
            var mockSet = setupResult.MockSet;
            var dataSource = setupResult.DataSource;
            //ACT
            var result = _serviceUnderTest.Edit(new AuthorVM()
            {
                Id = 123,
                FirstName = "ServicEditShouldReturnTrue"
            });

            //ASSERT
            Assert.Contains(dataSource, x => x.FirstName == "ServicEditShouldReturnTrue");       
        }

        private MockSetupResult<Author,int> Setup(List<Author> inputDataSource)
        {
            //1.Setup data
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
            //2.Setup Db, reference to MockDbSet in helper for more detail.
            var mockSet = new MockDbSet<Author,int>(dataSource);
            var mockContext = new Mock<BookstoreContext>();
            mockContext.Setup(c => c.Set<Author>()).Returns(mockSet.Object);

            //3.Setup repo,service,uow
            AuthorRepo = new AuthorRepo(mockContext.Object);
            AuthorRepo = new AuthorRepo(mockContext.Object);
            Uow = new UnitOfWork(mockContext.Object);
            _uowService = new UnitOfWorkService(Uow);
            _serviceUnderTest = new AuthorService(_mapper, AuthorRepo);
            return new MockSetupResult<Author,int>
            {
                DataSource = dataSource,
                MockSet = mockSet
            };

        }
    }
}
