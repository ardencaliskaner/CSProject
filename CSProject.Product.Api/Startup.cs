using CSProject.Product.Api.Extensions;
using CSProject.Product.Data.ORM.Context;
using CSProject.Product.Data.Repository;
using CSProject.Product.Data.Repository.Interfaces;
using CSProject.Product.Services;
using CSProject.Product.Services.Interfaces;
using Infrastructure.ServiceDiscovery;
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
            services.ConfigureServices(_configuration);
            ConfigureConsul(services);

            ServiceDependency(services);

            services.AddMvc();
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<CSProjectProductContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ProductDB")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private void ConfigureConsul(IServiceCollection services)
        {
            var serviceConfig = _configuration.GetServiceConfig();

            services.RegisterConsulServices(serviceConfig);
        }


        private void ServiceDependency(IServiceCollection services)
        {
            services
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductService, ProductService>();
        }

    }
}
