using Consul;
using CSProject.Product.Api.Extensions;
using Infrastructure.ServiceDiscovery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSProject.Product.Api
{
    public class Startup
    {
        private static IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

            RegisterServiceToConsul();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServices(_configuration);
            services.AddHealthChecks();
            ConfigureConsul(services);
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

            app.UseHealthChecks("", GetHealthCheckOptions());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterServiceToConsul()
        {
            using (var client = new ConsulClient())
            {
                var registration = new AgentServiceRegistration()
                {
                    ID = "productapi",
                    Name = "productapi",
                    Address = "localhost",
                    Port = 4003,
                    Check = new AgentCheckRegistration()
                    {
                        HTTP = "http://localhost:4003",
                        Interval = TimeSpan.FromSeconds(10)
                    }
                };

                client.Agent.ServiceRegister(registration).Wait();
            }
        }

        private void ConfigureConsul(IServiceCollection services)
        {
            var serviceConfig = _configuration.GetServiceConfig();

            services.RegisterConsulServices(serviceConfig);
        }


        private HealthCheckOptions GetHealthCheckOptions()
        {
            var options = new HealthCheckOptions();
            options.ResponseWriter = async (c, r) =>
            {
                c.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(new
                {
                    status = r.Status.ToString(),
                    errors = r.Entries.Select(x => new { key = x.Key, value = x.Value.Status.ToString() }),
                    durations = r.TotalDuration.TotalMilliseconds.ToString()
                });

                await c.Response.WriteAsync(result);
            };

            return options;
        }
    }
}
