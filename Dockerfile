#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OSCRM/Core.Web.App/Core.Web.App.csproj", "Core.Web.App/"]
# COPY ["OSCRM/LakeMaster.Web.Api/LakeMaster.Web.Api.csproj", "LakeMaster.Web.Api/"]
# COPY ["OSCRM/Data.Warehouse.PostgreSQL/Data.Warehouse.PostgreSQL.csproj", "Data.Warehouse.PostgreSQL/"]
# COPY ["OSCRM/DB.Models/DB.Models.csproj", "DB.Models/"]
# COPY ["OSCRM/Shared.Lib/Shared.Lib.csproj", "Shared.Lib/"]
# COPY ["OSCRM/OSCRM.Web.Api/OSCRM.Web.Api.csproj", "OSCRM.Web.Api/"]
# COPY ["OSCRM/Rehearsal.Web.Api/Rehearsal.Web.Api.csproj", "Rehearsal.Web.Api/"]
RUN dotnet restore "./Core.Web.App/Core.Web.App.csproj"
COPY . .
WORKDIR "/src/OSCRM/Core.Web.App"
RUN dotnet build "./Core.Web.App.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Core.Web.App.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN mkdir -p "/app/Certificates"
COPY ["./OSCRM/Shared.Lib/Certificates/.aspnet/https/aspnetapp.pfx", "/app/Certificates"]

ENTRYPOINT ["dotnet", "Core.Web.App.dll"]
