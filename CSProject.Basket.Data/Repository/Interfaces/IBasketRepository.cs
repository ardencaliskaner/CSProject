using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Basket.Data.Repository.Interfaces
{
    public interface IBasketRepository
    {
        Task<List<ORM.Model.Basket>> GetAll();
    }
}
