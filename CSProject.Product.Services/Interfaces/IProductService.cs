using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
using CSProject.Dto.DataDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Product.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();

        Task<List<ProductResponseModel>> GetProductsWithId(List<ProductRequestModel> productRequestModels);
        Task<List<ProductDto>> GetAllWithCategories();
        Task<ProductStockResponseModel> GetProduct(ProductStockRequestModel productStockRequestModel);
    }
}
