using CSProject.Product.Data.ORM.Context;
using CSProject.Product.Data.Repository;
using CSProject.Product.Data.Repository.Interfaces;
using CSProject.Product.Services;
using CSProject.Product.Services.Interfaces;
using CSProject.SeedData.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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


            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            PrepDB.PrepPopulation(app);

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
