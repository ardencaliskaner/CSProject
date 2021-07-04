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
        public async Task<ApiResponse<List<BasketReponseModel>>> GetBaskets()
        {
            return new ApiResponse<List<BasketReponseModel>>()
            {
                Data = await _basketService.GetAll(),
                Message = "Success",
                Status = "200"
            };

        }

        [HttpPost("AddToBasket")]
        public async Task<ClientBasketResponseModel> AddToBasket([FromBody] AddBasketRequest addBasketRequest)
        {
            return await _basketService.AddToBasket(addBasketRequest);
        }
    }
}
