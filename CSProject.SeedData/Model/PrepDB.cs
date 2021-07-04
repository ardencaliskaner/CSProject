using CSProject.Basket.Data.ORM.Context;
using CSProject.Product.Data.ORM.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using CSProject.Basket.Data.ORM.Model;
using ProductEntity = CSProject.Product.Data.ORM.Model.Product;
using BasketEntity = CSProject.Basket.Data.ORM.Model.Basket;
using CSProject.Product.Data.ORM.Model;

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


                context.Category.AddRange(
                    new Category() { Name = "Elektronik", Description = "Elektronik", AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new Category() { Name = "Takı", Description = "Takı", AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new Category() { Name = "Ev-Eşyası", Description = "Ev-Eşyası", AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false }
                );


                context.Product.AddRange(
                    new ProductEntity() { CategoryId = 1, Name = "Bilgisayar", Stock = 20, Price = 7500, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new ProductEntity() { CategoryId = 1, Name = "Televizyon", Stock = 5, Price = 8000, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new ProductEntity() { CategoryId = 1, Name = "Telefon", Stock = 10, Price = 3500, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new ProductEntity() { CategoryId = 2, Name = "Kolye", Stock = 3, Price = 650, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new ProductEntity() { CategoryId = 2, Name = "Saat", Stock = 2, Price = 300, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new ProductEntity() { CategoryId = 2, Name = "Cüzdan", Stock = 1, Price = 50, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new ProductEntity() { CategoryId = 3, Name = "Tablo", Stock = 50, Price = 25, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new ProductEntity() { CategoryId = 3, Name = "Masa", Stock = 2, Price = 1200, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new ProductEntity() { CategoryId = 3, Name = "Sandalye", Stock = 16, Price = 150, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new ProductEntity() { CategoryId = 3, Name = "Sehpa", Stock = 0, Price = 50, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = false, IsDeleted = false }
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
                    new BasketEntity() { ClientId = 1, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketEntity() { ClientId = 2, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketEntity() { ClientId = 3, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false }
                );

                context.BasketProduct.AddRange(
                    new BasketProduct() { BasketId = 1, ProductId = 1, Quantity = 1, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketProduct() { BasketId = 1, ProductId = 2, Quantity = 1, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketProduct() { BasketId = 1, ProductId = 3, Quantity = 2, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketProduct() { BasketId = 1, ProductId = 5, Quantity = 1, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketProduct() { BasketId = 2, ProductId = 7, Quantity = 2, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketProduct() { BasketId = 2, ProductId = 8, Quantity = 1, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketProduct() { BasketId = 2, ProductId = 9, Quantity = 4, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketProduct() { BasketId = 3, ProductId = 6, Quantity = 1, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false },
                    new BasketProduct() { BasketId = 3, ProductId = 4, Quantity = 2, AddDate = DateTime.Now, UpdateDate = DateTime.Now, IsActive = true, IsDeleted = false }
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