using CSProject.Product.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CSProject.Product.Data.ORM.Context
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<CSProjectProductContext>());
            }
        }

        public static void SeedData(CSProjectProductContext context)
        {
            System.Console.WriteLine("Applying Migrations...");

            context.Database.Migrate();

            if (!context.Product.Any())
            {
                System.Console.WriteLine("Adding data - seeding...");

                context.Product.AddRange(
                    new Model.Product() { Name = "Tv" },
                    new Model.Product() { Name = "Phone" },
                    new Model.Product() { Name = "Pc" }
                );

                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}