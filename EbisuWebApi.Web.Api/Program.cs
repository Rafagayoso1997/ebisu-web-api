using EbisuWebApi.Application.Services.Contracts;
using EbisuWebApi.Application.Services.Implementations;
using EbisuWebApi.Crosscutting.Utils;
using EbisuWebApi.Web.Api.AntiXssMiddleware;
using EbisuWebApi.Web.Api.Configuration;
using EbisuWebApi.Web.Api.ExceptionMiddleware;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseKestrel(options => options.AddServerHeader = false);

builder.Services.AddControllers();
builder.Services.ConfigureWebAPILayer(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "EbisuWebApi", Version = "v1" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Host.UseSerilog( (context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();



// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseCors(x => x
   .SetIsOriginAllowed(origin => true)
   .AllowAnyMethod()
   .AllowAnyHeader()
   .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseMiddleware<AntiXssMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program { }