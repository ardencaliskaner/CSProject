using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Basket.Data.Repository.Interfaces
{
    public interface IBasketProductRepository
    {
        Task<List<ORM.Model.BasketProduct>> GetAll();

        Task<ORM.Model.BasketProduct> AddBasketProduct(int basketId, int productId, int quantity);

        Task<ORM.Model.BasketProduct> UpdateBasketProduct(int basketId, int productId, int quantity);

        Task<List<int>> GetBasketProductIds(int basketId);

        Task<ORM.Model.BasketProduct> GetWithBasketAndProductId(int basketId, int productId);

        Task<List<ORM.Model.BasketProduct>> GetAllWithBasketId(int basketId);

    }
}
