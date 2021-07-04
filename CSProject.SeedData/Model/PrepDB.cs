using CSProject.Basket.Data.ORM.Context;
using CSProject.Product.Data.ORM.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ProductEntity = CSProject.Product.Data.ORM.Model.Product;
using BasketEntity = CSProject.Basket.Data.ORM.Model.Basket;

namespace CSProject.SeedData.Model
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                Retry.Do(() => SeedProductData(serviceScope.ServiceProvider.GetService<CSProjectProductContext>()), TimeSpan.FromSeconds(15));

                Retry.Do(() => SeedBasketData(serviceScope.ServiceProvider.GetService<CSProjectBasketContext>()), TimeSpan.FromSeconds(15));
            }
        }

        public static void SeedProductData(CSProjectProductContext context)
        {
            Console.WriteLine("Applying ProductDB Migrations...");

            context.Database.Migrate();

            if (!context.Product.Any())
            {
                Console.WriteLine("Adding Product data - seeding...");

                context.Product.AddRange(
                    new ProductEntity() { Name = "Pc" },
                    new ProductEntity() { Name = "Tv" },
                    new ProductEntity() { Name = "Phone" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have product data - not seeding");
            }
        }

        public static void SeedBasketData(CSProjectBasketContext context)
        {
            Console.WriteLine("Applying ProductDB Migrations...");

            context.Database.Migrate();

            if (!context.Basket.Any())
            {
                Console.WriteLine("Adding Product data - seeding...");

                context.Basket.AddRange(
                    new BasketEntity() { IsActive = true, IsDeleted = false },
                    new BasketEntity() { IsActive = true, IsDeleted = false },
                    new BasketEntity() { IsActive = true, IsDeleted = true }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Already have product data - not seeding");
            }
        }
    }
}