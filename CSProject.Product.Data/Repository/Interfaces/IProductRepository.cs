using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
using CSProject.Product.Data.ORM.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Product.Data.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductResponseModel>> GetAllWithCategories();

        Task<List<ORM.Model.Product>> GetAll();

        Task<ORM.Model.Product> GetProduct(int Id);

        Task<List<ProductResponseModel>> GetProductsWithId(List<int> productIds);
    }
}
