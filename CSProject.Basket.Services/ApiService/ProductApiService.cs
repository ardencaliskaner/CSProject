using CSProject.Basket.Services.ApiService.Contracts;
using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
using CSProject.Dto.Validator;
using System.Linq;
using System.Threading.Tasks;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace CSProject.Basket.Services.ApiService
{
    public class ProductApiService : IProductApiService
    {
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
