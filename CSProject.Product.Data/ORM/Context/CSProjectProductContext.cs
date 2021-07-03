using Microsoft.EntityFrameworkCore;
using System;
using Entity = CSProject.Product.Data.ORM.Model;

namespace CSProject.Product.Data.ORM.Context
{

    public class CSProjectProductContext : DbContext
    {
        public CSProjectProductContext()
        {

        }

        public CSProjectProductContext(DbContextOptions<CSProjectProductContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            bool isLocal = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Local";

            var server = isLocal ? "localhost" : "ms-sql-server";
            var port = "1433";
            var user = "SA";
            var password = "Ardentest123";
            var database = "ProductDB";

            optionsBuilder.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={password};MultipleActiveResultSets=true");
        }

        public DbSet<Entity.Product> Product { get; set; }

    }
}
