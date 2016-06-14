﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace suggestive.web.test
{
    public class MyFirstUnitTest
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(42, 6*7);
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(42, 5 * 17);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}
