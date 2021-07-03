using CSProject.Product.Data.ORM.Context;
using CSProject.Product.Data.Repository.Base;
using CSProject.Product.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CSProject.Product.Data.Repository
{
    public class ProductRepository : BaseRepository<ORM.Model.Product>, IProductRepository
    {
        public void SeedData()
        {
            var context = new CSProjectProductContext();

            context.Database.Migrate();

            context.Product.AddRange(
                new ORM.Model.Product() { Name = "Tv" },
                new ORM.Model.Product() { Name = "Phone" },
                new ORM.Model.Product() { Name = "Pc" }
            );

            context.SaveChanges();

        }

    }
}
