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
        public async Task<List<Dto.DataDto.ProductDto>> GetAll()
        {
            return await _productService.GetAll();
        }

        [HttpPost("GetProducts")]
        public async Task<List<ProductResponseModel>> GetProducts([FromBody] List<ProductRequestModel> productRequestModels)
        {
            return await _productService.GetProductsWithId(productRequestModels);
        }

        [HttpGet("GetAllWithCategories")]
        public async Task<List<Dto.DataDto.ProductDto>> GetAllWithCategories()
        {
            return await _productService.GetAllWithCategories();
        }

        [HttpPost("GetProductStock")]
        public async Task<Dto.DataDto.ProductDto> GetProductStock([FromBody] ProductStockRequestModel productStockRequestModel)
        {
            return await _productService.GetProduct(productStockRequestModel);
        }

    }
}
