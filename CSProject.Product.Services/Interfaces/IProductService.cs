using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Product.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponseModel>> GetAll();

        Task<List<ProductResponseModel>> GetProductsWithId(List<ProductRequestModel> productRequestModels);
        Task<List<ProductResponseModel>> GetAllWithCategories();
        Task<ProductStockResponseModel> GetProduct(ProductStockRequestModel productStockRequestModel);
    }
}
