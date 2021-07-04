using CSProject.Dto.DataDto;
using CSProject.Basket.Data.Repository.Interfaces;
using CSProject.Basket.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using CSProject.Dto.DataDto.Request;

namespace CSProject.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketProductRepository _basketProductRepository;


        public BasketService(IBasketRepository basketRepository, IBasketProductRepository basketProductRepository)
        {
            _basketRepository = basketRepository;
            _basketProductRepository = basketProductRepository;
        }

        public async Task<List<BasketDto>> GetAll()
        {
            var basketEntites = await _basketRepository.GetAll().ConfigureAwait(false);
            return Mapper.Map<List<BasketDto>>(basketEntites);
        }

        public async Task<List<BasketDto>> AddToBasket(AddBasketRequest addBasketRequest)
        {
            var basketId = GetOrSetClientBasket(addBasketRequest.ClientId);




            var basketEntites = await _basketRepository.GetAll().ConfigureAwait(false);
            return Mapper.Map<List<BasketDto>>(basketEntites);
        }


        private async Task<int> GetOrSetClientBasket(int clientId)
        {
            return 1;
        }

    }
}
