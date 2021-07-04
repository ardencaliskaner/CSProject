using CSProject.Product.Data.ORM.Context;
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
            var carObject = await _context.Product
                .Where(x => x.IsActive && !x.IsDeleted)
                .ToListAsync().ConfigureAwait(false);

            return carObject;
        }


        public async Task<object> GetAllWithCategories()
        {
            var carObject = await _context.Product
                //.Where(x => x.IsActive && !x.IsDeleted)
                .Join(_context.Category, pr => pr.CategoryId, cr => cr.Id, (pr, cr) => new
                {
                    Product = pr,
                    Category = cr
                }).Select(s => new
                {
                    id = s.Product.Id,
                    cid = s.Category.Id,
                    stock = s.Product.Stock
                })
                .ToListAsync().ConfigureAwait(false);

            var aaaa = carObject;

            return carObject;
        }
    }
}
