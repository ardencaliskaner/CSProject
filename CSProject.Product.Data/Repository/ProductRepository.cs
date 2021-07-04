using CSProject.Product.Data.ORM.Context;
using CSProject.Product.Data.ORM.Model;
using CSProject.Product.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSProject.Product.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly CSProjectProductContext _context;

        public ProductRepository(CSProjectProductContext context)
        {
            _context = context;
        }

        public async Task<List<ORM.Model.Product>> GetAll()
        {
            var products = await _context.Product
                .Where(x => x.IsActive && !x.IsDeleted)
                .ToListAsync().ConfigureAwait(false);

            return products;
        }


        public async Task<List<ProductVM>> GetAllWithCategories()
        {
            List<ProductVM> products = await _context.Product
                //.Where(x => x.IsActive && !x.IsDeleted)
                .Join(_context.Category, pr => pr.CategoryId, cr => cr.Id, (pr, cr) => new
                {
                    Product = pr,
                    Category = cr
                }).Select(s => new ProductVM
                {
                    Id = s.Product.Id,
                    CategoryId = s.Product.CategoryId,
                    Name = s.Product.Name,
                    Stock = s.Product.Stock,
                    Price = s.Product.Price,
                    IsActive = s.Product.IsActive,
                    AddDate = s.Product.AddDate,
                    UpdateDate = s.Product.UpdateDate,
                    IsDeleted = s.Product.IsDeleted,
                    DeletedDate = s.Product.DeletedDate,
                    Category = s.Category
                })
                .ToListAsync().ConfigureAwait(false);
            return products;
        }
    }
}
