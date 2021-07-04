using CSProject.Basket.Data.ORM.Context;
using CSProject.Basket.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<ORM.Model.Basket> CheckClientBasket(int clientId)
        {
            return await _context.Basket
                .Where(x => x.IsActive && !x.IsDeleted && x.ClientId == clientId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task<ORM.Model.Basket> CreateBasket(int clientId)
        {
            var basket = new ORM.Model.Basket
            {
                ClientId = clientId,
                IsActive = true,
                IsDeleted = false,
                AddDate = DateTime.Now,
                UpdateDate = DateTime.Now,
            };

            await _context.Basket.AddAsync(basket).ConfigureAwait(false);
            await _context.SaveChangesAsync();

            return basket;
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
