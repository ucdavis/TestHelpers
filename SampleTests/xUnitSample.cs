using System;
using System.Collections.Generic;
using System.Text;
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
            
            Should.Throw<EqualException>(() =>
                {
                    Assert.Equal(4, 1 + 1);
                })
                .Message.ShouldBe("Assert.Equal() Failure\r\nExpected: 4\r\nActual:   2");
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
