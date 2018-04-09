using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestHelpers.Helpers
{
    public class ContextHelper<TContext> where TContext : Microsoft.EntityFrameworkCore.DbContext , IDisposable
    {
        private SqliteConnection Connection { get; }
        public TContext Context { get;}

        public ContextHelper()
        {
            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            var options = new DbContextOptionsBuilder<TContext>()
                .UseSqlite(Connection)
                .Options;
            Context = (TContext)Activator.CreateInstance(typeof(TContext), options); //Not sure if this is correct...
            //Context = new TContext(options);
            Context.Database.EnsureCreated();
        }


        public void Dispose()
        {
            Connection?.Close();
        }
    }
}
