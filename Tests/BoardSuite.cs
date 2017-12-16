using System;
using System.Collections.Generic;
using Xunit;
namespace letskanban.Tests
{
    public class BoardSuite
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        private int Add(int v1, int v2)
        {
            return v1 + v2;
        }

    }
}