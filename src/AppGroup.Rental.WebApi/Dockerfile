#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AppGroup.Rental.WebApi/AppGroup.Rental.WebApi.csproj", "src/AppGroup.Rental.WebApi/"]
COPY ["src/AppGroup.Rental.Application/AppGroup.Rental.Application.csproj", "src/AppGroup.Rental.Application/"]
COPY ["src/AppGroup.Rental.Domain/AppGroup.Rental.Domain.csproj", "src/AppGroup.Rental.Domain/"]
COPY ["src/AppGroup.Rental.Infrastructure.RabbitMQ/AppGroup.Rental.Infrastructure.RabbitMQ.csproj", "src/AppGroup.Rental.Infrastructure.RabbitMQ/"]
COPY ["src/AppGroup.Rental.Infrastructure.Database/AppGroup.Rental.Infrastructure.Database.csproj", "src/AppGroup.Rental.Infrastructure.Database/"]
RUN dotnet restore "./src/AppGroup.Rental.WebApi/AppGroup.Rental.WebApi.csproj"
COPY . .
WORKDIR "/src/src/AppGroup.Rental.WebApi"
RUN dotnet build "./AppGroup.Rental.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AppGroup.Rental.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppGroup.Rental.WebApi.dll"]