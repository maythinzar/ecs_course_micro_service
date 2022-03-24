using System;
using Xunit;

namespace Com.NUS.TestXUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int actual = 1 + 1;
            Assert.Equal(2, actual);
        }
    }
}
