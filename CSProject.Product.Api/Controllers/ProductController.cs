using CSProject.Product.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSProject.Product.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        public IActionResult GetProducts()
        {
            var productId = _productService.GetByProductId("Pc");

            return Ok(productId);
        }
    }
}
