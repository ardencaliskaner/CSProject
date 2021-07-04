using CSProject.Dto.DataDto;
using CSProject.Dto.Model;

namespace CSProject.Basket.Services.Interfaces
{
    public interface IBasketService : IBaseService<BasketDto, Data.ORM.Model.Basket>
    {
        bool AddBasket(int productId);
    }
}
