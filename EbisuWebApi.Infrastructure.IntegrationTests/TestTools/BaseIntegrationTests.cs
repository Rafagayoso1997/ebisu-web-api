using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Infrastructure.IntegrationTests.TestTools
{
    //[TestClass]¿?
    public class BaseIntegrationTests
    {
        protected DatabaseContext TestDbContext { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            TestDbContext = DatabaseFactory.CreateTestDatabase();
        }

        [TestCleanup]
        public void Cleanup()
        {
            DatabaseFactory.DisposeContext(TestDbContext);
        }
    }
}
