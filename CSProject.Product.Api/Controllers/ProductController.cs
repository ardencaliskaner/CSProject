using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSProject.Product.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public IActionResult GetProducts()
        {
            var products = new List<Models.Product>
            {
                new Models.Product {Id=0, Code="CWK001", Name="ASUS VS197DE", Description="17 inch display", Price=75.90m},
                new Models.Product {Id=1, Code="CWK002", Name="Logitech K120", Description="keyboard", Price=11.24m},
                new Models.Product {Id=2, Code="CWK003", Name="Lenovo V330 laptop", Description="Business laptop", Price=704.78m}
            };

            return Ok(products);
        }
    }
}
