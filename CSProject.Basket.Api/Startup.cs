using CSProject.Basket.Api.Extensions;
using CSProject.Basket.Data.Repository;
using CSProject.Basket.Data.Repository.Interfaces;
using CSProject.Basket.Services;
using CSProject.Basket.Services.Interfaces;
using Infrastructure.ServiceDiscovery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSProject.Basket.Api
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
                .AddTransient<IBasketRepository, BasketRepository>()
                .AddTransient<IBasketService, BasketService>();
        }

    }
}
