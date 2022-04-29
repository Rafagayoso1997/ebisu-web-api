using EbisuWebApi.Application.Services.Configuration;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Application.Services.Implementations;

namespace EbisuWebApi.Web.Api.Configuration
{
    public static class IoC
    {
        public static IServiceCollection ConfigureWebAPILayer(this IServiceCollection services, IConfiguration configuration, WebApplicationBuilder builder)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITransactionService, TransactionService>();

            services.ConfigureServicesLayer(builder.Configuration);

            return services;
        }
    }
}
