using System;
using System.Collections.Generic;
using System.Text;
using TestHelpers.Helpers;
using Xunit;

namespace SampleTests
{
    [Trait("Category", "DatabaseTests")]
    public class DatabaseTests
    {

        //[Fact]
        //public void OrdersCanBeWrittenToDatabaseWithExistingUser()
        //{
        //    using (var contextHelper = new ContextHelper<ApplicationDbContext>())
        //    {

        //        contextHelper.Context.Orders.Count().ShouldBe(0);

        //        contextHelper.Context.Users.Add(CreateValidEntities.User(5));
        //        contextHelper.Context.SaveChanges();

        //        var order = CreateValidEntities.Order(1);
        //        order.Creator = contextHelper.Context.Users.FirstOrDefault();
        //        contextHelper.Context.Orders.Add(order);
        //        contextHelper.Context.SaveChanges();

        //        var updatedOrders = contextHelper.Context.Orders.Include(a => a.Creator).ToList();
        //        contextHelper.Context.Users.Count().ShouldBe(1);
        //        updatedOrders.Count().ShouldBe(1);


        //        updatedOrders[0].Creator.FirstName.ShouldBe("FirstName5");
        //    }
        //}

        //[Fact]
        //public void OrdersCanBeWrittenToDatabaseWithNewUser()
        //{
        //    using (var contextHelper = new ContextHelper<ApplicationDbContext>())
        //    {
        //        contextHelper.Context.Orders.Count().ShouldBe(0);

        //        contextHelper.Context.Users.Count().ShouldBe(0);


        //        contextHelper.Context.Users.Add(CreateValidEntities.User(5));
        //        contextHelper.Context.SaveChanges();

        //        var order = CreateValidEntities.Order(1);
        //        order.Creator = CreateValidEntities.User(3);
        //        contextHelper.Context.Orders.Add(order);
        //        contextHelper.Context.SaveChanges();

        //        var updatedOrders = contextHelper.Context.Orders.Include(a => a.Creator).ToList();
        //        contextHelper.Context.Users.Count().ShouldBe(2);
        //        updatedOrders.Count().ShouldBe(1);

        //        updatedOrders[0].Creator.FirstName.ShouldBe("FirstName3");
        //    }
        //}


        //[Fact]
        //public async Task TestTestAsyncSave()
        //{
        //    using (var contextHelper = new ContextHelper<ApplicationDbContext>())
        //    {

        //        (await contextHelper.Context.Orders.CountAsync()).ShouldBe(0);

        //        await contextHelper.Context.Users.AddAsync(CreateValidEntities.User(1));
        //        await contextHelper.Context.SaveChangesAsync();

        //        var order = CreateValidEntities.Order(1);
        //        order.Creator = await contextHelper.Context.Users.FirstOrDefaultAsync();
        //        await contextHelper.Context.Orders.AddAsync(order);
        //        await contextHelper.Context.SaveChangesAsync();

        //        (await contextHelper.Context.Orders.CountAsync()).ShouldBe(1);
        //    }

        //}

        //[Theory]
        //[InlineData(1)]
        //[InlineData(2)]
        //[InlineData(3)]
        //[InlineData(4)]
        //[InlineData(5)]
        //[InlineData(6)]
        //public void OrdersCanBeWrittenToDatabaseWithTheoryWithHelper(int value)
        //{
        //    using (var contextHelper = new ContextHelper<ApplicationDbContext>())
        //    {
        //        contextHelper.Context.Orders.Count().ShouldBe(0);

        //        contextHelper.Context.Users.Add(CreateValidEntities.User(1));
        //        contextHelper.Context.SaveChanges();

        //        for (int i = 0; i < value; i++)
        //        {

        //            var order = CreateValidEntities.Order(i + 1);
        //            order.Creator = contextHelper.Context.Users.FirstOrDefault();
        //            contextHelper.Context.Orders.Add(order);
        //        }


        //        contextHelper.Context.SaveChanges();

        //        contextHelper.Context.Orders.Count().ShouldBe(value);

        //    }

        //}
    }
}
