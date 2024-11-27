#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GPO BLAZOR/GPO BLAZOR/GPO BLAZOR.csproj", "GPO BLAZOR/GPO BLAZOR/"]
COPY ["GPO BLAZOR/GPO BLAZOR.Client/GPO BLAZOR.Client.csproj", "GPO BLAZOR/GPO BLAZOR.Client/"]
RUN dotnet restore "./GPO BLAZOR/GPO BLAZOR/GPO BLAZOR.csproj"
COPY . .
WORKDIR "/src/GPO BLAZOR/GPO BLAZOR"
RUN dotnet build "./GPO BLAZOR.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./GPO BLAZOR.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GPO_BLAZOR.dll"]