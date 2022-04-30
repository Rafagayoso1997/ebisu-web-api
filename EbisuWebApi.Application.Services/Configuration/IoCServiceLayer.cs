using EbisuWebApi.Crosscutting.ResourcesManagement;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using EbisuWebApi.Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EbisuWebApi.Application.Services.Configuration
{
    public static class IoCServiceLayer
    {
        private static readonly string connectionString = DatabaseConnection.ConnectionString;
        public static IServiceCollection ConfigureServicesLayer(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<DatabaseContext>(options =>
            {
                var serverVersion = new MySqlServerVersion(new Version(5, 6, 50));
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion);
            });


            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
