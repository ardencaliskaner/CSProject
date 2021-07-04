using CSProject.Basket.Data.ORM.Context;
using CSProject.Basket.Data.ORM.Model;
using CSProject.Basket.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<BasketProduct>> GetAll()
        {
            var basketProducts = await _context.BasketProduct
               .Where(x => x.IsActive && !x.IsDeleted)
               .ToListAsync().ConfigureAwait(false);

            return basketProducts;
        }
    }
}
