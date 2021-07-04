using CSProject.Basket.Data.ORM.Context;
using CSProject.Basket.Data.ORM.Model;
using CSProject.Basket.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSProject.Basket.Data.Repository
{
    public class BasketProductRepository : IBasketProductRepository
    {
        private readonly CSProjectBasketContext _context;

        public BasketProductRepository(CSProjectBasketContext context)
        {
            _context = context;
        }

        public async Task<BasketProduct> AddBasketProduct(int basketId, int productId, int quantity)
        {
            var basketProduct = new ORM.Model.BasketProduct
            {
                BasketId = basketId,
                ProductId = productId,
                Quantity = quantity,
                IsActive = true,
                IsDeleted = false,
                AddDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };

            await _context.BasketProduct.AddAsync(basketProduct).ConfigureAwait(false);
            await _context.SaveChangesAsync();

            return basketProduct;
        }

        public async Task<List<BasketProduct>> GetAll()
        {
            var basketProducts = await _context.BasketProduct
               .Where(x => x.IsActive && !x.IsDeleted)
               .ToListAsync().ConfigureAwait(false);

            return basketProducts;
        }
    }
}
