#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CSProject.Basket.Api/CSProject.Basket.Api.csproj", "CSProject.Basket.Api/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["CSProject.Basket.Data/CSProject.Basket.Data.csproj", "CSProject.Basket.Data/"]
COPY ["CSProject.Basket.Services/CSProject.Basket.Services.csproj", "CSProject.Basket.Services/"]
RUN dotnet restore "CSProject.Basket.Api/CSProject.Basket.Api.csproj"
COPY . .
WORKDIR "/src/CSProject.Basket.Api"
RUN dotnet build "CSProject.Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSProject.Basket.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSProject.Basket.Api.dll"]