using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using SampleTests.Models;
using Shouldly;
using TestHelpers.Helpers;
using Xunit;
using Xunit.Sdk;

namespace SampleTests
{
    [Trait("Category", "Sample")]
    public class XUnitSample
    {

        [Fact]
        public void Test1()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void BadMath()
        {
            Assert.Matches(@"Assert.Equal\(\) Failure\s+Expected: 4\s+Actual:   2",
                Should.Throw<EqualException>(() =>
                {
                    Assert.Equal(4, 1 + 1);
                }).Message);
        }

        [Theory]
        [InlineData(3, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        public void MyFirstTheory(int value, bool expected)
        {
            IsOdd(value).ShouldBe(expected);
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}
