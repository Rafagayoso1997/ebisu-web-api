using EbisuWebApi.Domain.Services.Contracts;
using EbisuWebApi.Domain.Services.Implementations;
using EbisuWebApi.Domain.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EbisuWebApi.Domain.Services.Configuration
{
    public static class IoCDomainLayer
    {
        public static IServiceCollection ConfigureDomainLayer(this IServiceCollection services)
        {

            services.AddTransient<IUserDomainService, UserDomainService>();
            services.AddTransient<ICategoryDomainService, CategoryDomainService>();
            services.AddTransient<ITransactionDomainService, TransactionDomainService>();

            services.AddValidatorsFromAssembly(typeof(UserDataModelValidator).Assembly);

            return services;
        }
    }
}
