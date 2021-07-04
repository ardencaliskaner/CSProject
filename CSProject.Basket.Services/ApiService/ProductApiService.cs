using CSProject.Basket.Services.ApiService.Contracts;
using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
using CSProject.Dto.Validator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace CSProject.Basket.Services.ApiService
{
    public class ProductApiService : IProductApiService
    {
        public async Task<ApiResponse<List<ProductResponseModel>>> GetClientBasketProducts(List<ProductRequestModel> productRequestModels)
        {

            if (!productRequestModels.Any())
            {
                return new ApiResponse<List<ProductResponseModel>>
                {
                    Status = "false",
                    Message = "Sepette ürün bulunamadı",
                };
            }

            BaseApiService<List<ProductRequestModel>, List<ProductResponseModel>> baseApiService = new BaseApiService<List<ProductRequestModel>, List<ProductResponseModel>>();

            ApiResponse<List<ProductResponseModel>> baseResponse = await baseApiService.GetDataFromApi(productRequestModels, "api/Product/GetProducts");

            return baseResponse;
        }

        public async Task<ApiResponse<ProductStockResponseModel>> GetProductStock(ProductStockRequestModel productStockRequestModel)
        {
            var validator = new RequestValidator();
            ValidationResult validationResult = await validator.ValidateAsync(productStockRequestModel);

            if (!validationResult.IsValid)
            {
                string errorMessage = validationResult.Errors?.First()?.ErrorMessage;

                return new ApiResponse<ProductStockResponseModel>
                {
                    Status = "false",
                    Message = errorMessage,
                };
            }

            BaseApiService<ProductStockRequestModel, ProductStockResponseModel> baseApiService = new BaseApiService<ProductStockRequestModel, ProductStockResponseModel>();

            ApiResponse<ProductStockResponseModel> baseResponse = await baseApiService.GetDataFromApi(productStockRequestModel, "api/Product/GetProductStock");

            return baseResponse;

        }
    }
}
