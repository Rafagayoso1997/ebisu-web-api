using EbisuWebApi.Crosscutting.ResourcesManagement;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Domain.Services.Configuration;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using EbisuWebApi.Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EbisuWebApi.Application.Services.Configuration
{
    public static class IoCServiceLayer
    {
        private static readonly string connectionString = DatabaseConnection.ConnectionString();
        public static IServiceCollection ConfigureServicesLayer(this IServiceCollection services)
        {

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(AutoMapperServiceConfiguration));

            services.AddDbContext<DatabaseContext>(options =>
            {
                var serverVersion = new MySqlServerVersion(new Version(5, 6, 50));
                options.UseMySql(connectionString, serverVersion);
            });
            services.BuildServiceProvider().GetService<DatabaseContext>().Database.MigrateAsync();

            services.ConfigureDomainLayer();
            
            return services;
        }
    }
}
