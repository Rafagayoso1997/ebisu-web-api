using EbisuWebApi.Crosscutting.ResourcesManagement;
using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Domain.Services.Contracts;
using EbisuWebApi.Domain.Services.Implementations;
using EbisuWebApi.Domain.Validation;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using EbisuWebApi.Infrastructure.Repositories.Implementations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EbisuWebApi.Application.Services.Configuration
{
    public static class IoCServiceLayer
    {
        private static readonly string connectionString = DatabaseConnection.ConnectionString;
        public static IServiceCollection ConfigureServicesLayer(this IServiceCollection services)
        {
            
            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ITransactionDomainService, TransactionDomainService>();
            
            services.AddTransient<IUserRepository, UserRepository>();
            
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddValidatorsFromAssembly(typeof(UserDataModelValidator).Assembly);

            services.AddDbContext<DatabaseContext>(options =>
            {
                var serverVersion = new MySqlServerVersion(new Version(5, 6, 50));
                options.UseMySql(connectionString, serverVersion);
            });
            services.BuildServiceProvider().GetService<DatabaseContext>().Database.MigrateAsync();
            
            return services;
        }
    }
}
