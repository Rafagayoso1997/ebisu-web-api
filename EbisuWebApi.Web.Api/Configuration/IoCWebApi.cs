using EbisuWebApi.Application.Services.Configuration;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Application.Services.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EbisuWebApi.Web.Api.Configuration
{
    public static class IoCWebApi
    {
        public static IServiceCollection ConfigureWebAPILayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET_KEY")))
                    };
                });
                
            services.ConfigureServicesLayer(configuration);

            return services;
        }
    }
}
