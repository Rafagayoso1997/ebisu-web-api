using EbisuWebApi.Domain.RepositoryContracts.Contracts;
using EbisuWebApi.Infrastructure.Persistence.DataBaseContext;
using EbisuWebApi.Infrastructure.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Application.Services.Configuration
{
    public static class IoC
    {
        public static IServiceCollection ConfigureServicesLayer(this IServiceCollection services)
        {
            
            var connectionString = "";
            services.AddDbContext<DataBaseContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
