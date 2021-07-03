using CSProject.Product.Data.ORM.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
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
                Retry.Do(() => SeedData(serviceScope.ServiceProvider.GetService<CSProjectProductContext>()), TimeSpan.FromSeconds(15));
            }
        }

        public static void SeedData(CSProjectProductContext context)
        {
            Console.WriteLine("Applying Migrations...");

            context.Database.Migrate();

            if (!context.Product.Any())
            {
                Console.WriteLine("Adding data - seeding...");

                context.Product.AddRange(
                    new ProductEntity() { Name = "Pc" },
                    new ProductEntity() { Name = "Tv" },
                    new ProductEntity() { Name = "Phone" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have data - not seeding");
            }
        }
    }
}