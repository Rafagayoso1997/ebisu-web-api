using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.IntegrationTests.TestTools
{
    public static class DatabaseFactory
    {
        private const string _connectionString = "Server=localhost;Database=EbisuTest;Uid=root;Pwd=ebisu2022.;";

        public static DatabaseContext CreateTestDatabase()
        {
            var serverVersion = new MySqlServerVersion(new Version(5, 6, 50));
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseMySql(_connectionString, serverVersion).Options;
            var dbcontext = new DatabaseContext(options);

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
