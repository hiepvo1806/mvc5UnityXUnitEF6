using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTestProject.Sample
{
    public class EqualExample
    {
        [Fact]
        public void EqualStringIgnoreCase()
        {
            string expected = "TestString";
            string actual = "teststring";

            Assert.False(actual == expected);
            Assert.NotEqual(expected, actual);
            Assert.Equal(expected, actual, StringComparer.CurrentCultureIgnoreCase);
        }
    }
}
