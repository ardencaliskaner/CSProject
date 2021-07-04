using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
using System.Threading.Tasks;

namespace CSProject.Basket.Services.ApiService.Contracts
{


    public interface IProductApiService
    {
        Task<ApiResponse<ProductStockResponseModel>> GetProductStock(ProductStockRequestModel productStockRequestModel);
    }
}
