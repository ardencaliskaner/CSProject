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


        [HttpGet("GetAllWithCategories")]
        public async Task<List<Dto.DataDto.ProductDto>> GetAllWithCategories()
        {
            return await _productService.GetAllWithCategories();
        }
    }
}
