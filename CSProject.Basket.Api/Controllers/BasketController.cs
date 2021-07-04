using CSProject.Basket.Services.Interfaces;
using CSProject.Dto.ApiModel.Response;
using CSProject.Dto.DataDto.Request;
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

        [HttpPost("AddToBasket")]
        public async Task<ClientBasketResponseModel> AddToBasket([FromBody] AddBasketRequest addBasketRequest)
        {
            return await _basketService.AddToBasket(addBasketRequest);
        }
    }
}
