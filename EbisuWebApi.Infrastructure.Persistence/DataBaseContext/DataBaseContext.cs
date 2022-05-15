using EbisuWebApi.Domain.Entities;
using EbisuWebApi.Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VuelingCF.Infrastructure.Repositories.Configurations;

namespace EbisuWebApi.Infrastructure.Persistence.DataBaseContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<CategoryDataModel> Categories { get; set; }

        public DbSet<TransactionDataModel> Transactions { get; set; }

        public DbSet<RoleDataModel> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}