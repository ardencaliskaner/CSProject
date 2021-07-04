using CSProject.Product.Data.ORM.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Product.Data.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductVM>> GetAllWithCategories();

        Task<List<ORM.Model.Product>> GetAll();
    }
}
