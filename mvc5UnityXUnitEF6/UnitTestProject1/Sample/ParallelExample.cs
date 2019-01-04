using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
namespace UnitTestProject.ParallelSample
{
    [Collection("Our Test Collection #1")]
    public class ParallelTest1
    {
        [Fact]
        public void Test1()
        {
            Thread.Sleep(3000);
        }
    }

    [Collection("Our Test Collection #1")]
    public class ParallelTest2
    {
        [Fact]
        public void Test2()
        {
            Thread.Sleep(5000);
        }
    }
}
