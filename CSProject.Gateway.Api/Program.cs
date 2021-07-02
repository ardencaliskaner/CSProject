using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore;
using System.IO;

namespace CSProject.Gateway.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((WebHostBuilderContext hostingContext, IConfigurationBuilder config) =>
           {
               config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath);
               config.AddJsonFile("appsettings.json");
               config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
               config.AddEnvironmentVariables();
           })
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();
    }
}