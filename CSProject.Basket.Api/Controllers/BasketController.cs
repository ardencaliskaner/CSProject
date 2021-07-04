using CSProject.Basket.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Basket.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }


        [HttpGet("GetBaskets")]
        public async Task<List<Dto.DataDto.BasketDto>> GetBaskets()
        {
            return await _basketService.GetAll();
        }

        //[HttpGet("AddBasket/{productId}")]
        //public IActionResult AddBasket(int productId)
        //{
        //    var basketId = _basketService.AddBasket(productId);

        //    return Ok(basketId);
        //}
    }
}
