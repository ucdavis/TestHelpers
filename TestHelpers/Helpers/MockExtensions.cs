﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestHelpers.Helpers
{
    public static class MockExtensions
    {
        public static Mock<DbSet<T>> MockDbSet<T>(this IQueryable<T> data) where T : class, new()
        {
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.As<IEnumerable<T>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            return mockSet;
        }

        public static Mock<DbSet<T>> MockAsyncDbSet<T>(this IQueryable<T> data) where T : class, new()
        {
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IAsyncEnumerable<T>>()
                .Setup(m => m.GetAsyncEnumerator(default))
                .Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));


            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<T>(data.Provider));

            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);

            mockSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.As<IEnumerable<T>>().Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
    }
}
