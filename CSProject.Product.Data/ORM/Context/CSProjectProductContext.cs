using Microsoft.EntityFrameworkCore;
using System;
using Entity = CSProject.Product.Data.ORM.Model;

namespace CSProject.Product.Data.ORM.Context
{

    public class CSProjectProductContext : DbContext
    {

        public CSProjectProductContext(DbContextOptions<CSProjectProductContext> options) : base(options)
        {

        }

        public DbSet<Entity.Category> Category { get; set; }

        public DbSet<Entity.Product> Product { get; set; }

    }
}
