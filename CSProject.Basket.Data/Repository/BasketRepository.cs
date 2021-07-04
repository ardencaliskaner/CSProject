using CSProject.Basket.Data.ORM.Context;
using CSProject.Basket.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSProject.Basket.Data.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly CSProjectBasketContext _context;

        public BasketRepository(CSProjectBasketContext context)
        {
            _context = context;
        }

        public async Task<List<ORM.Model.Basket>> GetAll()
        {
            var baskets = await _context.Basket
               .Where(x => x.IsActive && !x.IsDeleted)
               .ToListAsync().ConfigureAwait(false);

            return baskets;
        }
    }
}
