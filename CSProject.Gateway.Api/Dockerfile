#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CSProject.Gateway.Api/CSProject.Gateway.Api.csproj", "CSProject.Gateway.Api/"]
RUN dotnet restore "CSProject.Gateway.Api/CSProject.Gateway.Api.csproj"
COPY . .
WORKDIR "/src/CSProject.Gateway.Api"
RUN dotnet build "CSProject.Gateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSProject.Gateway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSProject.Gateway.Api.dll"]