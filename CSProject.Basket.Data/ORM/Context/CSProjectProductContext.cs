﻿using Microsoft.EntityFrameworkCore;
using System;
using Entity = CSProject.Basket.Data.ORM.Model;

namespace CSProject.Basket.Data.ORM.Context
{

    public class CSProjectBasketContext : DbContext
    {
        public CSProjectBasketContext()
        {

        }

        public CSProjectBasketContext(DbContextOptions<CSProjectBasketContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            bool isLocal = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local";

            var server = isLocal ? "localhost" : "ms-sql-server";
            var port = "1433";
            var user = "SA";
            var password = "Ardentest123";
            var database = "BasketDB";

            optionsBuilder.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={password};MultipleActiveResultSets=true");
        }

        public DbSet<Entity.Basket> Basket { get; set; }

    }
}
