using CSProject.Dto.ApiModel.Request;
using CSProject.Dto.ApiModel.Response;
using CSProject.Product.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Product.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<ApiResponse<List<ProductResponseModel>>> GetAll()
        {
            return new ApiResponse<List<ProductResponseModel>>()
            {
                Data = await _productService.GetAll(),
                Message = "Success",
                Status = "200"
            };
        }

        [HttpPost("GetProducts")]
        public async Task<ApiResponse<List<ProductResponseModel>>> GetProducts([FromBody] List<ProductRequestModel> productRequestModels)
        {
            return new ApiResponse<List<ProductResponseModel>>()
            {
                Data = await _productService.GetProductsWithId(productRequestModels),
                Message = "Success",
                Status = "200"
            };
        }

        [HttpGet("GetAllWithCategories")]
        public async Task<ApiResponse<List<ProductResponseModel>>> GetAllWithCategories()
        {
            return new ApiResponse<List<ProductResponseModel>>()
            {
                Data = await _productService.GetAllWithCategories(),
                Message = "Success",
                Status = "200"
            };

        }

        [HttpPost("GetProductStock")]
        public async Task<ApiResponse<ProductStockResponseModel>> GetProductStock([FromBody] ProductStockRequestModel productStockRequestModel)
        {
            return new ApiResponse<ProductStockResponseModel>()
            {
                Data = await _productService.GetProduct(productStockRequestModel),
                Message = "Success",
                Status = "200"
            };
        }

    }
}
