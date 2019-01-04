using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer.Models;
using Moq;
using ServiceLayer;

namespace UnitTestProject.Helper
{
    public class MockDbSet<TEntity, TKey> : Mock<DbSet<TEntity>> where TEntity : BaseEntityWithKey<TKey>
    {
        public MockDbSet(List<TEntity> dataSource = null)
        {
            var data = (dataSource ?? new List<TEntity>());
            var queryable = data.AsQueryable();

            As<IQueryable<TEntity>>().Setup(e => e.Provider).Returns(queryable.Provider);
            As<IQueryable<TEntity>>().Setup(e => e.Expression).Returns(queryable.Expression);
            As<IQueryable<TEntity>>().Setup(e => e.ElementType).Returns(queryable.ElementType);
            As<IQueryable<TEntity>>().Setup(e => e.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            //Error setup here
            //As<IQueryable<TEntity>>().Setup(e => e.GetFirstCreateItem()).Returns(()=>queryable.FirstOrDefault());

            //Mocking the insertion of entities
            Setup(_ => _.Add(It.IsAny<TEntity>())).Returns((TEntity arg) =>
            {
                data.Add(arg);
                return arg;
            });
            //...the same can be done for other members like Remove
            Setup(_ => _.Remove(It.IsAny<TEntity>())).Returns((TEntity arg) =>
            {
                data.Remove(arg);
                return arg;
            });

            Setup(_ => _.Find(It.IsAny<object[]>())).Returns((object[] args) =>
            {
                return data.Find(x => x.Id.ToString() == args[0].ToString());
            });
        }
    }
}
