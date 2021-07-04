using CSProject.Dto.DataDto;
using CSProject.Basket.Data.Repository.Interfaces;
using CSProject.Basket.Services.Base;
using CSProject.Basket.Services.Interfaces;
using CSProject.Dto.Model;
using CSProject.Basket.Data.ORM.Model;

namespace CSProject.Basket.Services
{
    public class BasketService : BaseService<BasketDto, Data.ORM.Model.Basket>, IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketProductRepository _basketProductRepository;


        public BasketService(IBasketRepository basketRepository, IBasketProductRepository basketProductRepository) : base(basketRepository)
        {
            _basketRepository = basketRepository;
            _basketProductRepository = basketProductRepository;
        }

        public bool AddBasket(int productId)
        {
            var entity = new BasketProduct
            {
                BasketId = 1,
                ProductId = productId,
                Quantity = 1
            };

            _basketProductRepository.Insert(entity);

            return true;
        }
    }
}
