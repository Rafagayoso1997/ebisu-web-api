using EbisuWebApi.Application.Dtos;
using EbisuWebApi.Application.Services.Configuration;
using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Application.Services.Implementations;

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace EbisuWebApi.Web.Api.Configuration
{
    public static class IoCWebApi
    {
        public static IServiceCollection ConfigureWebAPILayer(this IServiceCollection services)
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

            services.AddApiVersioning(o =>
             {
                 o.AssumeDefaultVersionWhenUnspecified = true;
                 o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                 o.ReportApiVersions = true;
                 o.ApiVersionReader = ApiVersionReader.Combine(
                     new QueryStringApiVersionReader("api-version"),
                     new HeaderApiVersionReader("X-Version"),
                     new MediaTypeApiVersionReader("ver"));
             });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.ConfigureServicesLayer();

            return services;
        }
    }
}
