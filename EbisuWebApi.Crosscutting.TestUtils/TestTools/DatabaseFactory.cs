
using EbisuWebApi.Crosscutting.ResourcesManagement;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.IntegrationTests.TestTools
{
    public static class DatabaseFactory
    {
        private readonly static string _connectionString = DatabaseConnection.DatabaseTestConnectionString();

        public static DatabaseContext CreateTestDatabase()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)).Options;
            var dbcontext = new DatabaseContext(options);
            dbcontext.Database.Migrate();
            //TODO: añadir seeds

            return dbcontext;
        }

        public static DatabaseContext CreateInMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().
                UseInMemoryDatabase("EbisuMemoryTest")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            var dbcontext = new DatabaseContext(options);
            //dbcontext.Database.Migrate();
            //TODO: añadir seeds

            return dbcontext;
        }

        public static void DisposeContext(DatabaseContext databaseContext)
        {
            databaseContext.Database.EnsureDeleted();
            databaseContext.Dispose();
        }
    }
}
