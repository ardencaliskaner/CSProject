using CSProject.Basket.Data.ORM.Context;
using CSProject.Product.Data.ORM.Context;
using CSProject.SeedData.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CSProject.Product.Api
{
    public class Startup
    {
        private static IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;


        }
        public void ConfigureServices(IServiceCollection services)
        {
            var server = _configuration["DBServer"] ?? "localhost";
            var port = _configuration["DBPort"] ?? "1433";
            var user = _configuration["DBUser"] ?? "SA";
            var password = _configuration["DBPassword"] ?? "Ardentest123";
            var database = _configuration["Database"] ?? "ProductDB";

            services.AddDbContext<CSProjectProductContext>(options =>
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={password};MultipleActiveResultSets=true"));


            ConfigureDBToService<CSProjectProductContext>(
                services,
                _configuration["DBServer"] ?? "localhost",
                _configuration["DBPort"] ?? "1433",
                _configuration["DBUser"] ?? "SA",
                _configuration["DBPassword"] ?? "Ardentest123",
                _configuration["Database"] ?? "ProductDB");

            ConfigureDBToService<CSProjectBasketContext>(
                services,
                _configuration["DBServer"] ?? "localhost",
                _configuration["DBPort"] ?? "1433",
                _configuration["DBUser"] ?? "SA",
                _configuration["DBPassword"] ?? "Ardentest123",
                _configuration["Database"] ?? "BasketDB");

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            PrepDB.PrepPopulation(app);
        }


        private void ConfigureDBToService<TContext>(IServiceCollection services, string server, string port, string user, string password, string database)
        where TContext : DbContext
        {
            services.AddDbContext<TContext>(options =>
                options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={password};MultipleActiveResultSets=true"));
        }
    }
}
