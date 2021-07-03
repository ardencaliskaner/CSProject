using CSProject.Product.Data.ORM.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using ProductEntity = CSProject.Product.Data.ORM.Model.Product;

namespace CSProject.SeedData.Model
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

            var pr = context.Product;

            if (!context.Product.Any())
            {
                System.Console.WriteLine("Adding data - seeding...");

                context.Product.AddRange(
                    new ProductEntity() { Name = "Pc" },
                    new ProductEntity() { Name = "Tv" },
                    new ProductEntity() { Name = "Phone" }
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