#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["CSProject.Product.Api/CSProject.Product.Api.csproj", "CSProject.Product.Api/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["CSProject.Product.Data/CSProject.Product.Data.csproj", "CSProject.Product.Data/"]
COPY ["CSProject.Product.Services/CSProject.Product.Services.csproj", "CSProject.Product.Services/"]
RUN dotnet restore "CSProject.Product.Api/CSProject.Product.Api.csproj"
COPY . .
WORKDIR "/src/CSProject.Product.Api"
RUN dotnet build "CSProject.Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSProject.Product.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSProject.Product.Api.dll"]