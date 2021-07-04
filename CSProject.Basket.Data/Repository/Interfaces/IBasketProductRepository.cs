using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Basket.Data.Repository.Interfaces
{
    public interface IBasketProductRepository
    {
        Task<List<ORM.Model.BasketProduct>> GetAll();
    }
}
