using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
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


        public async Task<ORM.Model.Product> GetProduct(int Id)
        {
            var product = await _context.Product
               .Where(x => x.IsActive && !x.IsDeleted && x.Id == Id)
               .FirstOrDefaultAsync()
               .ConfigureAwait(false);

            return product;
        }

        public async Task<List<ORM.Model.Product>> GetAll()
        {
            var products = await _context.Product
                .Where(x => x.IsActive && !x.IsDeleted)
                .ToListAsync().ConfigureAwait(false);

            return products;
        }


        public async Task<List<ProductResponseModel>> GetAllWithCategories()
        {
            List<ProductResponseModel> products = await _context.Product
                //.Where(x => x.IsActive && !x.IsDeleted)
                .Join(_context.Category, pr => pr.CategoryId, cr => cr.Id, (pr, cr) => new
                {
                    Product = pr,
                    Category = cr
                }).Select(s => new ProductResponseModel
                {
                    ProductId = s.Product.Id,
                    CategoryId = s.Product.CategoryId,
                    CategoryName = s.Category.Name,
                    Name = s.Product.Name,
                    Stock = s.Product.Stock,
                    Price = s.Product.Price,
                    IsActive = s.Product.IsActive,
                    AddDate = s.Product.AddDate,
                    UpdateDate = s.Product.UpdateDate,
                    IsDeleted = s.Product.IsDeleted,
                })
                .ToListAsync().ConfigureAwait(false);
            return products;
        }


        public async Task<List<ProductResponseModel>> GetProductsWithId(List<int> productIds)
        {
            List<ProductResponseModel> products = await _context.Product
             .Where(x => productIds.Contains(x.Id))
             .Join(_context.Category, pr => pr.CategoryId, cr => cr.Id, (pr, cr) => new
             {
                 Product = pr,
                 Category = cr
             }).Select(s => new ProductResponseModel
             {
                 ProductId = s.Product.Id,
                 CategoryId = s.Product.CategoryId,
                 CategoryName = s.Category.Name,
                 Name = s.Product.Name,
                 Stock = s.Product.Stock,
                 Price = s.Product.Price,
                 IsActive = s.Product.IsActive,
                 AddDate = s.Product.AddDate,
                 UpdateDate = s.Product.UpdateDate,
                 IsDeleted = s.Product.IsDeleted
             })
             .ToListAsync().ConfigureAwait(false);
            return products;

        }
    }
}
