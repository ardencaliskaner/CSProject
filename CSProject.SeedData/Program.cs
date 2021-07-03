using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace CSProject.Product.Api
{
    public class Program
    {
        //    public static void Main(string[] args)
        //    {
        //        BuildWebHost(args).Run();
        //    }

        //    public static IWebHost BuildWebHost(string[] args) =>
        //        WebHost.CreateDefaultBuilder(args)
        //            .ConfigureAppConfiguration(config =>
        //            {
        //                config.AddJsonFile("appsettings.json");
        //                config.AddEnvironmentVariables();
        //            })
        //            .UseStartup<Startup>()
        //            .Build();
        //}

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}