using EbisuWebApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuelingCF.Infrastructure.Repositories.Configurations;

namespace EbisuWebApi.Infrastructure.Persistence.DataBaseContext
{
    public class DataBaseContext  : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserModelConfiguration());

        }
    }
}
