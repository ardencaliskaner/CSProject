using Microsoft.EntityFrameworkCore;
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
            //var server = Configuration["DBServer"] ?? "localhost";
            //var port = Configuration["DBPort"] ?? "1433";
            //var user = Configuration["DBUser"] ?? "SA";
            //var password = Configuration["DBPassword"] ?? "Ardentest123";
            //var database = Configuration["Database"] ?? "Colours";

            //var server = "localhost";
            var server = "ms-sql-server";
            var port = "1433";
            var user = "SA";
            var password = "Ardentest123";
            var database = "ProductDB";

            optionsBuilder.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={password};MultipleActiveResultSets=true");


            //optionsBuilder.UseSqlServer(@"Data Source=YOURLOCALDBNAME;Database=ArmutProjectDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Entity.Product> Product { get; set; }

    }
}
