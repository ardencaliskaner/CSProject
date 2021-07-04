using CSProject.Dto.ApiModel.Response;
using CSProject.Dto.DataDto.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSProject.Basket.Services.Interfaces
{
    public interface IBasketService
    {
        Task<List<BasketReponseModel>> GetAll();
        Task<ClientBasketResponseModel> AddToBasket(AddBasketRequest addBasketRequest);
    }
}
