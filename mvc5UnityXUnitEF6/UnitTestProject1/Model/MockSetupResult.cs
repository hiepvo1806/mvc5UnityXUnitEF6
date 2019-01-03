using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using UnitTestProject.Helper;

namespace UnitTestProject1.Model
{
    public class MockSetupResult<T, TK> where T : BaseEntityWithKey<TK>
    {
        public MockDbSet<T, TK> MockSet { get; set; }
        public List<T> DataSource { get; set; }
    }
}
