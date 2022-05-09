using EbisuWebApi.Infrastructure.IntegrationTests.TestTools;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Crosscutting.TestUtils.TestTools
{
    public class BaseInMemoryUnitTest
    {
        protected DatabaseContext TestDbContext { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            TestDbContext = DatabaseFactory.CreateInMemoryDatabase();
        }

        [TestCleanup]
        public void Cleanup()
        {
            DatabaseFactory.DisposeContext(TestDbContext);
        }
    }
}
