using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using ServiceLayer.Models;
using Xunit;
using ServiceLayer.Service;
using DataAccessLayer.Repo;
using DataAccessLayer.Models;
using ServiceLayer;

namespace UnitTestProject.Sample
{
    public class UsingMoq
    {
        protected Mock<IAuthorRepo> _mockRepo { get; set; }
        protected IMapper _mapper { get; set; }

        protected IAuthorService service { get; set; }
        public UsingMoq()
        {
            _mockRepo = new Mock<IAuthorRepo>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceMapperProfile());
            });
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void ServiceDetailShouldReturnMockItem()
        {
            var expected = new Author()
            {
                Age = 123,
                Books = new List<Book>(),
                FirstName = "Just Mocked First Name",
                Id = 123,
                LastName = "Just Mocked Last Name"
            };
            _mockRepo.Setup(foo => foo.Details(123)).Returns(expected);
            service = new AuthorService(_mapper, _mockRepo.Object);

            var actual = service.Details(123);
            Assert.Equal("hello world",actual.FirstName);
        }

        [Fact]
        public void ServiceDetailShouldNotReturnMockItem()
        {
            var expected = new Author()
            {
                Age = 123,
                Books = new List<Book>(),
                FirstName = "Just Mocked First Name",
                Id = 123,
                LastName = "Just Mocked Last Name"
            };
            _mockRepo.Setup(foo => foo.Details(123)).Returns(expected);
            service = new AuthorService(_mapper, _mockRepo.Object);

            var actual = service.Details(123);
            Assert.Equal(actual.FirstName, expected.FirstName );
        }
    }
}
