using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Basket.Data.Repository.Interfaces
{
    public interface IBasketProductRepository
    {
        Task<List<ORM.Model.BasketProduct>> GetAll();

        Task<ORM.Model.BasketProduct> AddBasketProduct(int basketId, int productId, int quantity);
    }
}
