using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Product.Data.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<object> GetAllWithCategories();

        Task<List<ORM.Model.Product>> GetAll();
    }
}
