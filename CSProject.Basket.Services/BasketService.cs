using CSProject.Dto.DataDto;
using CSProject.Basket.Data.Repository.Interfaces;
using CSProject.Basket.Services.Base;
using CSProject.Basket.Services.Interfaces;

namespace CSProject.Basket.Services
{
    public class BasketService : BaseService<BasketDto, Data.ORM.Model.Basket>, IBasketService
    {
        private readonly IBasketRepository _basketRepository;


        public BasketService(IBasketRepository basketRepository) : base(basketRepository)
        {
            _basketRepository = basketRepository;
        }
    }
}
