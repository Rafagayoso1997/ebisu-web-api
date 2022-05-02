#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EbisuWebApi.Web.Api/EbisuWebApi.Web.Api.csproj", "EbisuWebApi.Web.Api/"]
COPY ["EbisuWebApi.Web.Validation/EbisuWebApi.Web.Validation.csproj", "EbisuWebApi.Web.Validation/"]
COPY ["EbisuWebApi.Application.Dtos/EbisuWebApi.Application.Dtos.csproj", "EbisuWebApi.Application.Dtos/"]
COPY ["EbisuWebApi.Application.Services/EbisuWebApi.Application.Services.csproj", "EbisuWebApi.Application.Services/"]
COPY ["EbisuWebApi.Crosscutting.ResourcesManagement/EbisuWebApi.Crosscutting.ResourcesManagement.csproj", "EbisuWebApi.Crosscutting.ResourcesManagement/"]
COPY ["EbisuWebApi.Crosscutting.Security/EbisuWebApi.Crosscutting.Security.csproj", "EbisuWebApi.Crosscutting.Security/"]
COPY ["EbisuWebApi.Crosscutting.Utils/EbisuWebApi.Crosscutting.Utils.csproj", "EbisuWebApi.Crosscutting.Utils/"]
COPY ["EbisuWebApi.Domain.Entities/EbisuWebApi.Domain.Entities.csproj", "EbisuWebApi.Domain.Entities/"]
COPY ["EbisuWebApi.Domain.RepositoryContracts/EbisuWebApi.Domain.RepositoryContracts.csproj", "EbisuWebApi.Domain.RepositoryContracts/"]
COPY ["EbisuWebApi.Domain.Services/EbisuWebApi.Domain.Services.csproj", "EbisuWebApi.Domain.Services/"]
COPY ["EbisuWebApi.Infrastructure.DataModel/EbisuWebApi.Infrastructure.DataModel.csproj", "EbisuWebApi.Infrastructure.DataModel/"]
COPY ["EbisuWebApi.Infrastructure.Persistence/EbisuWebApi.Infrastructure.Persistence.csproj", "EbisuWebApi.Infrastructure.Persistence/"]
COPY ["EbisuWebApi.Infrastructure.Repositories/EbisuWebApi.Infrastructure.Repositories.csproj", "EbisuWebApi.Infrastructure.Repositories/"]
RUN dotnet restore "EbisuWebApi.Web.Api/EbisuWebApi.Web.Api.csproj"
COPY . .
WORKDIR "/src/EbisuWebApi.Web.Api"
RUN dotnet build "EbisuWebApi.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EbisuWebApi.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "EbisuWebApi.Web.Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet EbisuWebApi.Web.Api.dll